using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PirateBattle.Views {
    public class SessionTimeView : MonoBehaviour
    {
        float sessionTotalTime = 0;
        float sessionStartTime = -1;

        [SerializeField]
        TMPro.TMP_Text textSessionTime;

        float lastUpdate = 0;

        const float UPDATE_STEP = 0.2f;

        void OnEnable() {
            EventManager.StartListening("startSession", OnSessionStart);
        }

        void OnDisable() {
            EventManager.StopListening("startSession", OnSessionStart);
        }
        
        void OnSessionStart(Dictionary<string, object> message) {
            sessionTotalTime = (float) message["sessionTotalTime"];
            sessionStartTime = Time.time;
            sessionEnded = false;
            StartCoroutine(WaitEndOfSession());
        }

        void Update() {
            var elapsedTime = Time.time - sessionStartTime;
            if(Time.time > sessionStartTime &&
                sessionStartTime >= 0 &&
                Time.time <= sessionStartTime + sessionTotalTime * 60f &&
                Time.time > lastUpdate + UPDATE_STEP) {
                textSessionTime.text = "Time remaining (mm:ss): " + FormatTimeInSecondsAsMinutesAndSecs(elapsedTime);
                lastUpdate = Time.time;
            }
            else if(Time.time > lastUpdate + UPDATE_STEP) {
                Debug.Log($"sessionStartTime {sessionStartTime} Time.time {Time.time}");
                textSessionTime.text = "Time remaining (mm:ss): " + FormatTimeInSecondsAsMinutesAndSecs(elapsedTime);
                lastUpdate = Time.time;
            }   
        }

        void Start() {
            sessionStartTime = Time.time;
            if(sessionTotalTime == 0) {
                sessionTotalTime = 3f;
            }
            if(PlayerPrefs.GetInt("SessionTime") != 0) {
                sessionTotalTime = (float)PlayerPrefs.GetInt("SessionTime");
            }
        }
        
        IEnumerator WaitEndOfSession() {
            yield return new WaitForSeconds(sessionTotalTime * 60f);
            EventManager.TriggerEvent("endSession", new Dictionary<string, object> { { "endedSession", 1 } });
        }
        bool sessionEnded = false;

        string FormatTimeInSecondsAsMinutesAndSecs(float timeInSeconds) {
            if(sessionEnded) return "00:00";
            var remainingTime = sessionTotalTime * 60f - timeInSeconds;
            
            if(remainingTime < 0) {
                remainingTime = 0;
            }
            if(remainingTime == 0) {
                EventManager.TriggerEvent("endSession", new Dictionary<string, object> { { "endedSession", 1 } });
                sessionEnded = true;
            }
            TimeSpan t = TimeSpan.FromSeconds(remainingTime);
            return string.Format("{0:D2}:{1:D2}", 
                t.Minutes, 
                t.Seconds);            
        }

        public void SetSessionTotalTime(float totalTime) {
            sessionTotalTime = totalTime;
        }
    }

}

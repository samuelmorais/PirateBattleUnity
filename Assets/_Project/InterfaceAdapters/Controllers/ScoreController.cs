using UnityEngine;
using System.Collections.Generic;

namespace PirateBattle.InterfaceAdapters {    
    public class ScoreController : MonoBehaviour {
        float currentScore = 0;
        [SerializeField]
        TMPro.TMP_Text textCurrentScore;

        void OnEnable() {
            EventManager.StartListening("addPoints", OnAddPoints);
        }

        void OnDisable() {
            EventManager.StopListening("addPoints", OnAddPoints);
        }
        
        void OnAddPoints(Dictionary<string, object> message) {
            var ammount = (int) message["ammount"];
            Debug.Log($"Added {ammount} points.");
            currentScore += ammount;
            UpdateView();
        }

        void UpdateView() {
            textCurrentScore.text = $"Points: {currentScore}";
        }
    }
}
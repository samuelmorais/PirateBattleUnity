using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionEndedView : MonoBehaviour
{
    [SerializeField]
    GameObject SessionEndedPanel;
    void OnEnable() {
        EventManager.StartListening("endSession", OnEndSession);
        EventManager.StartListening("playerShipDestroyed", OnEndSession);
    }

    void OnDisable() {
        EventManager.StopListening("endSession", OnEndSession);
        EventManager.StartListening("playerShipDestroyed", OnEndSession);
    }
    
    void OnEndSession(Dictionary<string, object> message) {
        ShowSessionEndedPanel();
    }

    void ShowSessionEndedPanel() {
        try{
            SessionEndedPanel.SetActive(true);
        }
        catch(System.Exception ex) {
            
        }
    }
}

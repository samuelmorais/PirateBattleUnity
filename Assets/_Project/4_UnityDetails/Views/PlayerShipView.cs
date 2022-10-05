using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PirateBattle.Views {
    public class PlayerShipView : MonoBehaviour
    {
        [SerializeField]
        GameObject playerShip;

        [SerializeField]
        TMPro.TMP_Text healthUIText;

        void OnEnable() {
            EventManager.StartListening("updateHealth", SubscribeToHealthEvent);
        }

        void OnDisable() {
            EventManager.StopListening("updateHealth", SubscribeToHealthEvent);
        }

        private void SubscribeToHealthEvent(Dictionary<string, object> message) {
            var newHealth = (int) message["newHealth"];
            healthUIText.text = $"Health: {newHealth}";
        }
    }

}

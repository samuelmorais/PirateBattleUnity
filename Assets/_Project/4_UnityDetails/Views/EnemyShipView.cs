using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PirateBattle.Views {
    public class EnemyShipView : MonoBehaviour
    {
        [SerializeField]
        GameObject playerShip;

        void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        }
    }

}

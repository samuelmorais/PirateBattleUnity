using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PirateBattle.Views {
    public class GameConfigView : MonoBehaviour
    {
        [SerializeField]
        float shipSpeed;

        [SerializeField]
        float enemySpeed;

        [SerializeField]
        float damageAmmount;

        [SerializeField]
        float startingHealth;

        [SerializeField]
        GameObject playerShip;

        List<GameObject> enemyShips;

        float currentScore;
    }

}

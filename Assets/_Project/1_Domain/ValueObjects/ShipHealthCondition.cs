using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PirateBattle.Domain.ValueObjects {
    public class ShipHealthCondition
    {
        float currentHealth;
        
        public ShipHealthCondition(float initialHealth){
            currentHealth = initialHealth;
        }

        public ShipHealthCondition AddHealth(float ammount) {
            return new ShipHealthCondition(currentHealth + ammount);
        }

        public ShipHealthCondition SubtractHealth(float ammount) {
            var finalHealth = currentHealth - ammount;
            if(finalHealth < 0) finalHealth = 0;
            return new ShipHealthCondition(finalHealth);
        }
    }
}

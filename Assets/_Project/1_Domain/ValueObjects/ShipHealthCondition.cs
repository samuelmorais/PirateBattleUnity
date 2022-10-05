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

        public ShipHealthCondition SubtractHealth(Damage damage, float minimumHealth) {
            var finalHealth = currentHealth - damage.Ammount;
            if(finalHealth < 0) finalHealth = minimumHealth;
            return new ShipHealthCondition(finalHealth);
        }
    }
}

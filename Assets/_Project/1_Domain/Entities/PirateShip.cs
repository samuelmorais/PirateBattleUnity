using PirateBattle.Domain.ValueObjects;
using PirateBattle.Domain.Contracts;

namespace PirateBattle.Domain.Entities {
    public class PirateShip : IDamageable
    {
        public PirateShip(){
            
        }

        public ShipHealthCondition TakeDamage(Damage ammount, ShipHealthCondition currentHealth)
        {
            var substractedHealth = currentHealth.SubtractHealth(ammount);
            return substractedHealth;
        }

    }
}


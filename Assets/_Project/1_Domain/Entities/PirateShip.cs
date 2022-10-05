using PirateBattle.Domain.ValueObjects;

namespace PirateBattle.Domain.Entities {
    public class PirateShip 
    {
        float minimumHealth = 0;
        float maximumHealth;

        public PirateShip(float minimumHealth, float maximumHealth) {
            this.minimumHealth = minimumHealth;
            this.maximumHealth = maximumHealth;
        }
        public ShipHealthCondition TakeDamage(Damage ammount, ShipHealthCondition currentHealth)
        {
            var substractedHealth = currentHealth.SubtractHealth(ammount, minimumHealth);
            return substractedHealth;
        }
    }
}


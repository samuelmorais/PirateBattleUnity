using PirateBattle.Domain.ValueObjects;

namespace PirateBattle.Domain.Contracts
{
    public interface IDamageable
    {
        public void TakeDamage(Damage damage);
    }
}
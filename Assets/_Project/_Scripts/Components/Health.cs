using System;

namespace Assets._Project._Scripts.Models
{
    public class Health
    {
        public event Action Died;
        public event Action<float,float> HealthChanged;

        private float _maxHealth;
        private float _health;

        public Health(float maxHealth)
        {
            _maxHealth = _health = maxHealth;
        }

        public void Initialize()
        {
            HealthChanged?.Invoke(_health, _maxHealth);
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            _health = Math.Clamp(_health, 0, _maxHealth);
            HealthChanged?.Invoke(_health,_maxHealth);

            if (_health == 0)
                Died?.Invoke();
        }
    }
}

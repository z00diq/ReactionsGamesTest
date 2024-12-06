using UnityEngine;
using Assets._Project._Scripts.Enemies.Components;
using Assets._Project._Scripts.Models;

namespace Assets._Project._Scripts.Views
{
    public class Player : MonoBehaviour
    {
        public Health Health => _health;

        [SerializeField] private float _speed;
        [SerializeField] private float _maxHealth;

        private Health _health;
        private PlayerMover _mover;
        private Vector3 _moveVector;

        private void OnEnable()
        {
            _health = new Health(_maxHealth);
            _mover = new PlayerMover(transform, _speed);
            _health.Died += Die;
        }

        private void OnDisable()
        {
            _health.Died -= Die;
        }

        private void Start()
        {
            _health.Initialize();
        }

        private void Update()
        {
            _mover.Move(transform.position + _moveVector);
        }

        public void SetMoveVector(Vector3 vector)
        {
            _moveVector = vector;
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Explode damager))
                _health.TakeDamage(damager.Damage);
        }
    }
}

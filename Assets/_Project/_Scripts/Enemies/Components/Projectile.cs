using UnityEngine;

namespace Assets._Project._Scripts.Enemies.Components
{
    public class Projectile : Explode
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;

        private Vector3 _flightDirection;
        private float _ellapsedTime = 0;

        private void Update()
        {
            _ellapsedTime += Time.deltaTime;

            if (_ellapsedTime >= _lifeTime)
                Destroy(gameObject);

            Vector3 nextPosition = transform.position + _flightDirection;
            transform.position =Vector3.MoveTowards(transform.position , nextPosition, _speed*Time.deltaTime);
        }

        public void Initialize(Vector3 flightDirection)
        {
            _flightDirection = flightDirection;
        }
    }
}

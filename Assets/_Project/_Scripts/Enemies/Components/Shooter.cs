using Assets._Project._Scripts.Views;
using UnityEngine;

namespace Assets._Project._Scripts.Enemies.Components
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Projectile _prefab;
        [SerializeField] private Transform _projectileSpawner;
        [SerializeField] private AgroZone _agroZone;
        [SerializeField] private float _reloadTime;

        private float _ellapsedTime;
        private Player _target;

        private void OnEnable()
        {
            _ellapsedTime = _reloadTime;
            _agroZone.TargetIsSpotted += TargetIsSpotted;
        }

        private void TargetIsSpotted(Player target)
        {
            _target = target;
        }

        private void Start()
        {
            _ellapsedTime = _reloadTime;
        }

        private void Update()
        {
            if (_target == null)
                return;

            transform.LookAt(_target.transform);

            _ellapsedTime += Time.deltaTime;

            if( _ellapsedTime >= _reloadTime)
            {
                Fire();
                _ellapsedTime = 0;
            }
        }

        private void Fire()
        {
            Projectile projectile = Instantiate(_prefab, _projectileSpawner.position,Quaternion.identity);
            Vector3 direction = _target.transform.position - _projectileSpawner.transform.position;
            direction = direction.normalized;
            projectile.Initialize(direction);
        }
    }
}

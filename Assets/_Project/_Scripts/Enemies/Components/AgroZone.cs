using UnityEngine;
using System;
using Assets._Project._Scripts.Views;

namespace Assets._Project._Scripts.Enemies.Components
{
    [RequireComponent(typeof(SphereCollider))]
    public class AgroZone : MonoBehaviour
    {
        public event Action<Player> TargetIsSpotted;

        [SerializeField] private float _agroRadius;

        private SphereCollider _agroZone;

        private void OnEnable()
        {
            _agroZone = GetComponent<SphereCollider>();
            _agroZone.radius = _agroRadius;
            _agroZone.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
                TargetIsSpotted?.Invoke(player);
        }
    }
}

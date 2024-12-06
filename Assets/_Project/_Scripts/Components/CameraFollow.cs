using UnityEngine;
using System;
using Zenject;
using Assets._Project._Scripts.Views;

namespace Assets._Project._Scripts.Components
{
    [RequireComponent(typeof(Camera))]
    public class CameraFollow: MonoBehaviour
    {
        [SerializeField, Range(10f,30)] private float offsetDistance;
        [SerializeField, Range(1f, 5)] private float _smoothSpeed;
        [SerializeField] private Vector3 _offset;

        private Player _target;

        private void LateUpdate()
        {
            if (_target == null)
                return;

            Vector3 position = _target.transform.position + _offset;
            position -= transform.forward * offsetDistance;
            transform.position = Vector3.Lerp(transform.position, position, _smoothSpeed * Time.deltaTime);
        }

        [Inject]
        public void Initialize(Player target)
        {
            _target=target;
        }
    }
}

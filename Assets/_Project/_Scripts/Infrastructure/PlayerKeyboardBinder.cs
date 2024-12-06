using Assets._Project._Scripts.Views;
using UnityEngine;
using Zenject;

namespace Assets._Project._Scripts.Infrastructure
{
    public class PlayerKeyboardBinder : ITickable
    {
        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);

        private readonly Player _mover;
        private Vector3 _inputData = Vector3.zero;

        public PlayerKeyboardBinder(Player mover)
        {
            _mover = mover;
        }

        void ITickable.Tick()
        {
            _inputData.x = Input.GetAxisRaw(Horizontal);
            _inputData.z = Input.GetAxisRaw(Vertical);
            _mover.SetMoveVector(_inputData);
        }
    }
}

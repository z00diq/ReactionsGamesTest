using UnityEngine;

namespace Assets._Project._Scripts.Models
{
    public class PlayerMover
    {
        private Transform _self;
        private float _speed;

        public PlayerMover(Transform self, float speed)
        {
            _self = self;
            _speed = speed;
        }

        public void Move(Vector3 targetPosition)
        {
            _self.position = Vector3.MoveTowards(_self.position, targetPosition, _speed * Time.deltaTime);
        }
    }
}

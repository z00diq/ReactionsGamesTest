using UnityEngine;
using UnityEngine.AI;

namespace Assets._Project._Scripts.Enemies.Components
{
    public class EnemyMover
    {
        private Transform _self;
        private float _speed;
        private NavMeshAgent _agent;

        public EnemyMover(Transform self, float speed, NavMeshAgent agent)
        {
            _self = self;
            _speed = speed;
            _agent = agent;
        }

        public void Move(Vector3 targetPosition)
        {
            _agent.nextPosition = Vector3.MoveTowards(_self.position, targetPosition, _speed * Time.deltaTime);
        }
    }
}

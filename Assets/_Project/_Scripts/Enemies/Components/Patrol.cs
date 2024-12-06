using UnityEngine.AI;
using UnityEngine;
using System.Collections.Generic;

namespace Assets._Project._Scripts.Enemies.Components
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Patrol : MonoBehaviour
    {
        private const float DISTANCE_OFFSET = 0.4f;

        [SerializeField] private float _speed;
        [SerializeField] private List<Transform> _path;

        private EnemyMover _mover;
        private NavMeshAgent _agent;
        private int _currentPoint = 0;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _mover = new EnemyMover(transform, _speed, _agent);
        }

        private void Update()
        {
            if ((transform.position - _path[_currentPoint].position).magnitude < DISTANCE_OFFSET)
                _currentPoint = ++_currentPoint % _path.Count;

            _mover.Move(_path[_currentPoint].position);            
        }
    }
}

using UnityEngine.AI;
using UnityEngine;
using Assets._Project._Scripts.Views;

namespace Assets._Project._Scripts.Enemies.Components
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Chase : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private AgroZone _agroZone;

        private EnemyMover _mover;
        private NavMeshAgent _agent;
        private Player _target;

        private void OnEnable()
        {
            _agroZone.TargetIsSpotted += TargetIsSpotted;
        }

        private void OnDisable()
        {
            _agroZone.TargetIsSpotted -= TargetIsSpotted;
        }

        private void Start()
        {   
            _agent = GetComponent<NavMeshAgent>();
            _mover = new EnemyMover(transform, _speed, _agent);
        }

        private void Update()
        {
            if (_target == null)
                return;
           
           _mover.Move(_target.transform.position);
        }

        private void DisablePatrolIfExist()
        {
            if (TryGetComponent(out Patrol patrol))
                if (patrol.enabled == true)
                    patrol.enabled = false;
        }

        private void TargetIsSpotted(Player target)
        {
            _target = target;
            DisablePatrolIfExist();
        }
    }
}

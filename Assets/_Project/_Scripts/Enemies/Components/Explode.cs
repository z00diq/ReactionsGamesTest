using Assets._Project._Scripts.Models;
using UnityEngine;

namespace Assets._Project._Scripts.Enemies.Components
{
    [RequireComponent(typeof(Collider))]
    public class Explode : MonoBehaviour
    {
        public float Damage => _damage;
        
        [SerializeField] private float _damage;

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {  
              Destroy(gameObject);
        }
    }
}

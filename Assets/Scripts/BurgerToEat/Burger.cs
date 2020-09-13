using UnityEngine;

namespace BurgerToEat
{
    public class Burger : MonoBehaviour
    {
        [SerializeField] private GameObject crunchParticlePrefab;
        internal BurgerManager manager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Instantiate(crunchParticlePrefab, transform.position, crunchParticlePrefab.transform.rotation);
                manager.BurgerIsFinished();
            }
        }
    }
}
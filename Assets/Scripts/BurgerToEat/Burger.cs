using UnityEngine;

namespace BurgerToEat
{
    [RequireComponent(typeof(AudioSource))]
    public class Burger : MonoBehaviour
    {
        [SerializeField] private int maxCount = 4;
        [SerializeField] private AudioClip[] eatSounds;

        internal BurgerManager manager;

        private int currentCount = 0;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                currentCount++;
                audioSource.PlayOneShot(eatSounds[Random.Range(0, eatSounds.Length)]);
                if (currentCount >= maxCount)
                {
                    manager.BurgerIsFinished();
                }
            }
        }
    }
}
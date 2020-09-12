using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerToEat
{
    [RequireComponent(typeof(AudioSource))]
    public class BurgerManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform leftHand;
        [SerializeField] private Transform rightHand;
        [SerializeField] private GameObject burgerPrefab;

        private GameObject currentBurger;
        private EHand currentHand;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            currentHand = EHand.Right;
            GenerateBurger();
        }

        private void GenerateBurger()
        {
            currentBurger = Instantiate(burgerPrefab, currentHand == EHand.Right ? rightHand : leftHand);
            currentBurger.transform.localPosition = Vector3.zero;
            currentBurger.transform.localRotation = Quaternion.identity;
            currentBurger.GetComponent<Burger>().manager = this;
        }

        public void BurgerIsFinished()
        {
            Destroy(currentBurger);
            //GameManager.Instance.scoreManager.UpdateScore();
            audioSource.Play();
            currentHand = currentHand == EHand.Right ? EHand.Left : EHand.Right;
            GenerateBurger();
        }

        enum EHand
        {
            Left,
            Right
        }
    }
}

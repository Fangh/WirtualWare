using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField, Tooltip("If setup, will call OnTriggerEvent when an other object with this tag enter this gameobject collider")]
    private string triggerTag;

    [SerializeField] private UnityEvent OnTriggerEnterEvent;
    [SerializeField] private UnityEvent OnTriggerExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(triggerTag) && other.CompareTag(triggerTag))
        {
            OnTriggerEnterEvent?.Invoke();
        }
        else
            OnTriggerEnterEvent?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(triggerTag) && other.CompareTag(triggerTag))
        {
            OnTriggerExitEvent?.Invoke();
        }
        else
            OnTriggerExitEvent?.Invoke();
    }
}

using UnityEngine;
using UnityEngine.Events;

public class OutTheDoorEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _outed;

    private void OnTriggerExit2D(Collider2D collision)
    {
        _outed.Invoke();
    }
}
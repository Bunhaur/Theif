using UnityEngine;
using UnityEngine.Events;

public class EnterTheDoorEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _entered.Invoke();
        }
    }
}
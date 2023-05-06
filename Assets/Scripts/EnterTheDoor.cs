using UnityEngine;

public class EnterTheDoor : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _alarm.OnEntering();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _alarm.OnExit();
    }
}
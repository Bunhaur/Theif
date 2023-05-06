using UnityEngine;

public class EnterTheDoor : MonoBehaviour
{
    [SerializeField] private AlramSystem _alramSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _alramSystem.OnEntering();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alramSystem.OnExit();
    }
}
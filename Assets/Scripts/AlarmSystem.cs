using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private bool isTrigger;
    private float _volumeChangeNumber;

    private void Start()
    {
        _audioSource.volume = 0;
        _volumeChangeNumber = 0.2f;
    }

    private void Update()
    {
        if (isTrigger == true)
        {
            _audioSource.volume += _volumeChangeNumber * Time.deltaTime;
        }
        else if (isTrigger == false && _audioSource.volume != 0)
        {
                _audioSource.volume -= _volumeChangeNumber * Time.deltaTime;
        }
        else
        {
            _audioSource.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _audioSource.Play();
            isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTrigger = false;
    }
}
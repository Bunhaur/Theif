using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _volumeCoroutine;

    private float _speedVolumeChange;
    private float _minVolume;
    private float _maxVolume;

    private void Start()
    {
        _speedVolumeChange = 0.25f;
        _minVolume = 0f;
        _maxVolume = 1.0f;
    }

    public void OnEntering()
    {
        if (_audioSource.volume == _maxVolume)
            _audioSource.volume = _minVolume;

        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ChangingVolume(_maxVolume));
    }

    public void OnExit()
    {
        StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ChangingVolume(_minVolume));
    }


    private IEnumerator ChangingVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _speedVolumeChange * Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();
    }
}

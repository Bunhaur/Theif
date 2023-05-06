using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AlramSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0f;
    private float _maxVolume = 1.0f;
    private float _changedVolumeSpeed;

    private Coroutine _volumeCoroutine;

    public void OnEntering()
    {
        if (_audioSource.volume == _maxVolume)
            _audioSource.volume = _minVolume;

        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        if (_volumeCoroutine != null)
            StopCoroutine( _volumeCoroutine );

        _volumeCoroutine = StartCoroutine(ChangingVolume(_maxVolume));
    }

    public void OnExit()
    {
        StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ChangingVolume(_minVolume));
    }

    private void Start()
    {
        _changedVolumeSpeed = 0.25f;
    }

    private IEnumerator ChangingVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _changedVolumeSpeed * Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();
    }
}
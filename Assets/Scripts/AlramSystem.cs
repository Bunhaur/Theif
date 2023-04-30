using System.Collections;
using UnityEngine;

public class AlramSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _volumeChangeSpeed = 0.2f;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;

    private IEnumerator _increateVolumeJob;
    private IEnumerator _decreateVolumeJob;

    public void Activate()
    {
        _audioSource.Play();

        if (_audioSource.volume == _maxVolume)
            _audioSource.volume = _minVolume;

        //StopCoroutine(_decreateVolumeJob);
        //StartCoroutine(_increateVolumeJob);

        StopCoroutine("DecreaseVolume");
        StartCoroutine("IncreaseVolume");
    }

    public void Deactivate()
    {
        //StopCoroutine(_decreateVolumeJob);
        //StartCoroutine(_increateVolumeJob);

        StopCoroutine("IncreaseVolume");
        StartCoroutine("DecreaseVolume");
    }

    private void Start()
    {
        _increateVolumeJob = IncreaseVolume();
        _decreateVolumeJob = DecreaseVolume();
    }

    private IEnumerator IncreaseVolume()
    {
        while (_audioSource.volume != _maxVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        while (_audioSource.volume != _minVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        _audioSource.Stop();
    }
}
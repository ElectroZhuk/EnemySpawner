using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadedAudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource _player;
    [SerializeField] float _fadeSeconds;
    [SerializeField] float _normalVolume;

    private float _target;
    private float _pauseSeconds;

    private void Awake()
    {
        _player.volume = 0;
        _pauseSeconds = _fadeSeconds / 100;
    }

    public void Play()
    {
        if (_player.isPlaying == false)
            _player.Play();
        _target = _normalVolume;
        StartCoroutine(ChangeVolume());
    }

    public void Stop()
    {
        _target = 0;
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_player.volume != _target)
        {
            _player.volume = Mathf.MoveTowards(_player.volume, _target, 0.01f);

            yield return new WaitForSeconds(_pauseSeconds);
        }

        if (_player.volume == 0f)
            _player.Stop();
    }
}

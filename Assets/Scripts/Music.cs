using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Music : MonoBehaviour
{
    // [SerializeField] private AudioManager AudioManager.Instance;

    private string[] _backgroundMusicNames = {"music1", "music2", "music3", "music4", "music5", "music6"};

    private List<string> _remainingMusicNamesToPlay = new List<string>();
    private string _currentMusicName = "";
    private bool _isPlayBackgroundMusic = true;


    private void Update()
    {
        if (_currentMusicName != "" && _isPlayBackgroundMusic)
        {
            if (AudioManager.Instance.GetSound(_currentMusicName).Source.time == 0 &&!AudioManager.Instance.GetSound(_currentMusicName).Source.isPlaying)
            {
                PlayRandomMusic();
            }
        }
    }


    public void PlayBackgroundMusic()
    {
        PlayRandomMusic();
        _isPlayBackgroundMusic = true;
    }

    private void PlayRandomMusic()
    {
        if (_remainingMusicNamesToPlay.Count == 0) {
            _remainingMusicNamesToPlay = GetShuffledMusicNames(_backgroundMusicNames);
        }
        _currentMusicName = _remainingMusicNamesToPlay[0];
        _remainingMusicNamesToPlay.RemoveAt(0);
        print(_currentMusicName);
        AudioManager.Instance.Play(_currentMusicName);
    }

    public void PlayGoodResultMusic()
    {
        _isPlayBackgroundMusic = false;
        AudioManager.Instance.Stop(_currentMusicName);
        _currentMusicName = "goodresult";
        AudioManager.Instance.Play(_currentMusicName);
    }

    public void PlayBadResultMusic()
    {
        _isPlayBackgroundMusic = false;
        AudioManager.Instance.Stop(_currentMusicName);
        _currentMusicName = "badresult";
        AudioManager.Instance.Play(_currentMusicName);
    }

    public void StopCurrentMusic()
    {
        AudioManager.Instance.Stop(_currentMusicName);
    }

    private List<string> GetShuffledMusicNames(string[] musicNames) {
        for (int i = 0; i < musicNames.Length; i++) {
            int rnd = UnityEngine.Random.Range(0, musicNames.Length);
            string temp = musicNames[rnd];
            musicNames[rnd] = musicNames[i];
            musicNames[i] = temp;
        }

        return musicNames.ToList();
    }
}

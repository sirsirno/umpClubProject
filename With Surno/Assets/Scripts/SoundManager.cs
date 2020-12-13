using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}
public class SoundManager : MonoBehaviour
{

    [Header("사운드 등록")]
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sfxSounds;

    [Header("브금 플레이어")]
    [SerializeField] AudioSource bgmPlayer;
    [Header("효과음 플레이어")]
    [SerializeField] AudioSource[] sfxPlayer;

    private int _x = 100;
    public float sfxVolume = 1;
    void Start()
    {
        BgmPlay();
    }
    private void Update()
    {
        bgmPlayer.volume = SaveGame.Instance._gameData.BGM;
        if (_x != 100)
            sfxPlayer[_x].volume = SaveGame.Instance._gameData.SFX;
        else
            sfxPlayer[_x].volume = 0;
    }
    private void BgmPlay()
    {
        bgmPlayer.clip = bgmSounds[0].clip;
        bgmPlayer.Play();
    }
    public void PlaySE(string _soundName)
    {
        for (int i = 0; i < sfxSounds.Length; i++)
        {
            if(_soundName == sfxSounds[i].soundName)
            {

                for (int x = 0; x < sfxPlayer.Length; x++)
                {
                    if (!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfxSounds[i].clip;
                        _x = x;
                        sfxPlayer[x].Play();
                    }
                }
                Debug.Log("모든 효과음 플레이어가 사용중입니다!!");
                return;
            }
        }
        Debug.Log("등록된 효과음이 없습니다.");
    }
}

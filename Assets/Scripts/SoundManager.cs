using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private static AudioClip playerJump;
    [SerializeField] private static AudioClip playerDeath;
    [SerializeField] private static AudioClip levelMusic;

    private static AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        playerJump = Resources.Load<AudioClip>("player-jump");
        playerDeath = Resources.Load<AudioClip>("Game_Over");
        levelMusic = Resources.Load<AudioClip>("Level_Music");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "player-jump":
                audioSource.PlayOneShot(playerJump);
                break;
            case "Game_Over":
                audioSource.PlayOneShot(playerDeath);
                break;
            case "Level_Music":
                audioSource.PlayOneShot(levelMusic);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip Coin, Jump, Slow;

    public static AudioClip JumpSound, CoinSound, SlowSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        JumpSound = Jump;
        CoinSound = Coin;
        SlowSound = Slow;
    }

    public static void PlaySound(string soundClip)
    {
        switch(soundClip)
        {
            case "Coin":
                audioSrc.PlayOneShot(CoinSound);
                break;
            case "Jump":
                audioSrc.PlayOneShot(JumpSound);
                break;
            case "Slow":
                audioSrc.PlayOneShot(SlowSound);
                break;
        }
    }
}

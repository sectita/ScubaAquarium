using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip teleport, hurt, win, outGameover;
    static AudioSource _audioSource;

    public AudioClip[] clips;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //Background
        _audioSource.clip = clips[Random.Range(0, clips.Length)]; //Background
        //OneShot
        _audioSource.loop = false;
        teleport = Resources.Load<AudioClip>("Blah");
        hurt = Resources.Load<AudioClip>("Hurt");
        win = Resources.Load<AudioClip>("Win");
        outGameover = Resources.Load<AudioClip>("Out");


        _audioSource.PlayOneShot(_audioSource.clip);
    }
    public static void PlaySound(string clip, bool switchbutton = true)
    {
        switch (clip)
        {
            case "Blah":
                _audioSource.PlayOneShot(teleport);
                switchbutton = false;
                break;
            case "Hurt":
                _audioSource.PlayOneShot(hurt);
                switchbutton = false;
                break;
            case "Win":
                _audioSource.PlayOneShot(win);
                switchbutton = false;
                break;
            case "Out":
                _audioSource.PlayOneShot(outGameover);
                switchbutton = false;
                break;

        }
    }
}

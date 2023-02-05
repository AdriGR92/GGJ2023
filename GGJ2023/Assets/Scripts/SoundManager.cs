using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffect(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }

    public void ChangeSound(AudioClip sound)
    {
        audioSource.Stop();
        audioSource.clip = sound;
        audioSource.Play();
    }
}

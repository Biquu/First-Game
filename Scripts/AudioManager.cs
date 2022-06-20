using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public AudioMixerGroup mixer;
    public Sound[] sounds;

    // AudioManagerin her sahne yüklenmesinde tekrar tekrar çalışmaması için.
    public static AudioManager instance;

    private int index;

    void Awake()
    {
        if (instance == null){// sahnede audio manager yoksa,
            instance = this;
        }else { // sahnede auido manager varsa bu objeyi kaldırmak istiyoruz.
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)   
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = mixer;
        }

    }

    private void Update()
    {
        if(playsNothing() == 1)
        {
            Play();
        }


       
    }
    private int playsNothing()
    {
        int check = 1;
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].source.isPlaying)
            {
                check = -1;
            }
 
        }
        return check;
    }
    void PlayNextSong()
    {
        Sound s = sounds[UnityEngine.Random.Range(0, sounds.Length)];
        s.source.Play();

    }


    public void Play()
    {
        

        while (playsNothing() == 1)
        {
            PlayNextSong();

        }          
    }

}


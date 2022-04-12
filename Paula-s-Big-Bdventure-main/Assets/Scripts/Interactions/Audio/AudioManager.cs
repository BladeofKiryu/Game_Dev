using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
   public Sound[] soundCatalog;

   public static AudioManager instance;

   void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
         return;
      }
      DontDestroyOnLoad(gameObject);

      foreach (Sound sound in soundCatalog)
      {
         sound.source = gameObject.AddComponent<AudioSource>();
         sound.source.clip = sound.clip;
         sound.source.volume = sound.volume;
         sound.source.pitch = sound.pitch;
         sound.source.loop = sound.loop;
      }
   }

   public void Play(GameSounds soundToPlay)
   {
      Sound soundFound = Array.Find(soundCatalog, sound => sound.whichSound == soundToPlay);
      if (soundFound == null)
      {
         return;
      }
      soundFound.source.Play();
   }
}

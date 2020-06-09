using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Audio {

    /// <summary>
    /// Manage game audio and audioclips.
    /// </summary>
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] AudioSource bgMusicSource;
        [SerializeField] AudioSource sfxSource;
        [SerializeField] AudioSource sfxLoopSource;

        // Store effect audio clips in a serialized list from inspector.
        [SerializeField] List<AudioClip> audioClipList;

        // Store effect audio clips in Key-Value pair by using filename as the key.
        private Dictionary<string, AudioClip> audioDictionary;

        public bool IsEffectPlaying {

            get
            {
                return sfxLoopSource.isPlaying;
            }
        }

        protected override void Awake()
        {
            base.Awake();

            audioDictionary = new Dictionary<string, AudioClip>();

            for (int i = 0; i < audioClipList.Count; i++)
            {
                audioDictionary.Add(audioClipList[i].name, audioClipList[i]);
            }
        }

        public void PlayEffect(string effectName)
        {
            sfxSource.PlayOneShot(audioDictionary[effectName]);
        }

        public void PlayLoopEffect(string effectName)
        {
            if (sfxLoopSource.isPlaying)
                return;

            sfxLoopSource.clip = audioDictionary[effectName];
            sfxLoopSource.loop = true;
            sfxLoopSource.Play();
        }

        public void StopLoopEffect()
        {
            sfxLoopSource.Stop();
        }

        public void PlayBgMusic()
        {
            bgMusicSource.Play();
        }

        public void PauseBgMusic()
        {
            bgMusicSource.Pause();
        }

        public void UnPauseBgMusic()
        {
            bgMusicSource.UnPause();
        }
    }
}
using System.Collections.Generic;
using AudioManagement.SoundType;
using Services.AudioService.Scripts;
using Services.AudioService.Scripts.ResourceManagement;
using UnityEngine;

namespace AudioManagement.Scripts.SoundType.Types
{
    /// <summary>
    /// Base class representing a sound.
    /// </summary>
    public class Sound
    {
        protected readonly SerializableDictionary<string, AudioClipDataSo> AudioClipData;

        protected SoundType Type { get; set; }
        
        public bool IsMute { get; protected set; }

        protected readonly SaveLoadSound SaveLoadSound;

        /// <summary>
        /// Initializes a new instance of the Sound class.
        /// </summary>
        /// <param name="audioClipData">Dictionary of AudioClipData objects.</param>
        public Sound(SerializableDictionary<string, AudioClipDataSo> audioClipData)
        {
            AudioClipData = audioClipData;
            SaveLoadSound = new SaveLoadSound();
        }
        
        /// <summary>
        /// Plays the specified AudioClipEnum on the given AudioSource.
        /// </summary>
        /// <param name="source">The AudioSource to play the clip on.</param>
        /// <param name="clip">The AudioClipEnum representing the desired clip to play.</param>
        public virtual void Play(AudioSource source, AudioClipEnum clip)
        {
            var audioClipDataSo = AudioClipData[clip.ToString()];
            if (audioClipDataSo != null) SetClipData(audioClipDataSo.data, source);
            source.Play();
        }

        /// <summary>
        /// Mutes or unmutes the specified pool of AudioSources.
        /// </summary>
        /// <param name="pool">The list of AudioSources to mute or unmute.</param>
        /// <param name="mute">Boolean value indicating whether to mute or unmute the sources.</param>
        public void Mute(ComponentPool<AudioSource> pool, bool mute)
        {
            foreach (var source in pool.Pool)
            {
                if(!source.clip)
                    continue;
                
                var clipName = source.clip.name;
                var formattedClipName = char.ToUpper(clipName[0]) + clipName.Substring(1);
                
                if (AudioClipData[formattedClipName].data.type == Type)
                    source.mute = mute;
            }

            IsMute = mute;
            SaveLoadSound.SaveMuteStatus(Type, IsMute);
        }

        /// <summary>
        /// Stops the specified clip.
        /// </summary>
        /// <param name="pool">The list of AudioSources to mute or unmute.</param>
        /// <param name="clip"></param>
        public void StopClip(ComponentPool<AudioSource> pool, AudioClipEnum clip)
        {
            foreach (var source in pool.Pool)
            {
                if(!source.clip)
                    continue;

                if (source.clip.name == clip.ToString())
                {
                    source.Stop();
                    source.clip = null;
                }
            }
        }
        
        /// <summary>
        /// Stops the specified pool of AudioSources.
        /// </summary>
        /// <param name="pool">The list of AudioSources to mute or unmute.</param>
        public void StopClips(ComponentPool<AudioSource> pool)
        {
            foreach (var source in pool.Pool)
            {
                if(!source.clip)
                    continue;
                
                var clipName = source.clip.name;
                var formattedClipName = char.ToUpper(clipName[0]) + clipName.Substring(1);

                if (AudioClipData[formattedClipName].data.type == Type)
                {
                    source.Stop();
                    source.clip = null;
                }
            }
        }
        
        private void SetClipData(AudioClipDataSo.AudioClipData clipData, AudioSource audioSource)
        {
            audioSource.clip = clipData.audioClip;
            audioSource.pitch = clipData.pitch;
            audioSource.volume = clipData.volume;
            audioSource.loop = clipData.loop;
        }
    }
}

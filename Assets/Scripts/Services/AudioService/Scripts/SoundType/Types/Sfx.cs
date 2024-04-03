using System.Collections.Generic;
using Services.AudioService.Scripts;
using Services.AudioService.Scripts.ResourceManagement;
using UnityEngine;

namespace AudioManagement.Scripts.SoundType.Types
{
    public class Sfx : Sound
    {
        private readonly Dictionary<AudioClipEnum, float> _sfxPlayData = new();

        public Sfx(SerializableDictionary<string, AudioClipDataSo> audioClipData) : base(audioClipData)
        {
            Type = SoundType.Sfx;
            IsMute = SaveLoadSound.LoadMuteStatus(SoundType.Sfx);
        }

        /// <summary>
        ///     Plays the specified AudioClipEnum on the given AudioSource.
        /// </summary>
        /// <param name="source">The AudioSource to play the clip on.</param>
        /// <param name="clip">The AudioClipEnum representing the desired clip to play.</param>
        public override void Play(AudioSource source, AudioClipEnum clip)
        {
            if (IsMute)
                return;

            if (_sfxPlayData.TryGetValue(clip, out var lastTimePlayed))
            {
                var infrequency = AudioClipData[clip.ToString()].data.infrequency;
                if (Mathf.Abs(Time.unscaledTime - lastTimePlayed) < infrequency)
                    return;
                _sfxPlayData[clip] = Time.unscaledTime;
            }
            else
                _sfxPlayData.Add(clip, Time.unscaledTime);

            base.Play(source, clip);
        }
    }
}
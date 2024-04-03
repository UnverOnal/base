using Services.AudioService.Scripts;
using Services.AudioService.Scripts.ResourceManagement;
using UnityEngine;

namespace AudioManagement.Scripts.SoundType.Types
{
    public class BackgroundMusic : Sound
    {
        public BackgroundMusic(SerializableDictionary<string, AudioClipDataSo> audioClipData) : base(audioClipData)
        {
            Type = SoundType.Background;
            IsMute = SaveLoadSound.LoadMuteStatus(SoundType.Background);
        }

        /// <summary>
        /// Plays the specified AudioClipEnum on the given AudioSource.
        /// </summary>
        /// <param name="source">The AudioSource to play the clip on.</param>
        /// <param name="clip">The AudioClipEnum representing the desired clip to play.</param>
        public override void Play(AudioSource source, AudioClipEnum clip)
        {
            source.mute = IsMute;
            
            base.Play(source, clip);
        }
    }
}
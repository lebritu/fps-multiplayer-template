using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace FMT.Gameplay
{
    public class SoundPool : MonoBehaviour
    {
        private static AudioSource _musicOutput;

        public static float Volume { get; set; }

        public static StepAudioClipGroup WoodStep { get; private set; }
        public static StepAudioClipGroup MetalStep { get; private set; }
        public static StepAudioClipGroup TileStep { get; private set; }
        public static StepAudioClipGroup concreteStep { get; private set; }
        public static StepAudioClipGroup GrassStep { get; private set; }

        private static bool IsPlaying { get; set; }

        protected void Start()
        {
            if (IsPlaying)
            {
                Destroy(gameObject);
            }
            else
            {
                IsPlaying = true;
                _musicOutput = GetComponent<AudioSource>();
                DontDestroyOnLoad(gameObject);
            }
        }

        public static AudioClip GetStepSound(MaterialEnum material)
        {
            switch (material)
            {
                case MaterialEnum.Wood:
                    return WoodStep.GetRandomClip();

                case MaterialEnum.Metal:
                    return MetalStep.GetRandomClip();

                case MaterialEnum.Tile:
                    return TileStep.GetRandomClip();

                case MaterialEnum.Grass:
                    return GrassStep.GetRandomClip();

                case MaterialEnum.Concrete:
                    return concreteStep.GetRandomClip();

                default:
                    return GrassStep.GetRandomClip();
            }
        }
    }

    [Serializable]
    public struct StepAudioClipGroup
    {
        public AudioClip[] AudioClips;

        public AudioClip GetRandomClip()
        {
            int randomNumber = UnityEngine.Random.Range(0, AudioClips.Length - 1);

            return AudioClips[randomNumber];
        }
    }
}

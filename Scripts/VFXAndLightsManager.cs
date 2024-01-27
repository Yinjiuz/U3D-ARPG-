using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using DG.Tweening;

namespace MyGame
{
    public class VFXAndLightsManager : MonoBehaviour
    {
        [Header("VFX")]
        public VisualEffect sparkVFX;
        public VisualEffect abilityVFX;
        public VisualEffect abilityHitVFX;
        public VisualEffect healVFX;

        public ParticleSystem fireParticle;
        public ParticleSystem waterParticle;
        [Space]
        [Header("Ligts")]
        public Light swordLight;
        public Light groundLight;
        [Header("Ligh Colors")]
        public Color sparkColor;
        public Color healColor;
        public Color abilityColot;

        public float VFXDir = 5;

        public CameraManager cameraManager;
        void Start()
        {
            cameraManager = GetComponent<CameraManager>();
            fireParticle.Stop();
            waterParticle.Stop();
        }
        public void PlayVFX(VisualEffect visualEffect, Vector3 position,  bool shakeCamera)
        {
            visualEffect.transform.position = position;
            if (visualEffect == abilityHitVFX)
                LightColor(groundLight, abilityColot, .2f, position);

            if (visualEffect == sparkVFX)
                visualEffect.SetFloat("PosX", VFXDir);
            visualEffect.SendEvent("OnPlay");

            float shakeAmplitude = 2;
            float shakeFrequency = 2;
            float shakeSustain = .2f;

            cameraManager.camImpulseSource.m_ImpulseDefinition.m_AmplitudeGain = shakeAmplitude;
            cameraManager.camImpulseSource.m_ImpulseDefinition.m_FrequencyGain = shakeFrequency;
            cameraManager.camImpulseSource.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = shakeSustain;
            if (shakeCamera)
                cameraManager.camImpulseSource.GenerateImpulse();
        }

        public void PlayParticle(ParticleSystem particle, Vector3 position)
        {
            particle.transform.position = position;
            particle.Play();
        }

        public void StopParticle(ParticleSystem particle)
        {
            particle.Stop();

        }
        public void DirRight()
        {
            VFXDir = -5;
        }

        public void DirLeft()
        {
            VFXDir = 5;
        }

        public void LightColor(Light l, Color x, float time,Vector3 position)
        {
            l.transform.position = position;
            l.DOColor(x, time).OnComplete(() => l.DOColor(Color.black, time));
        }
    }

}

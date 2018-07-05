using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeParticleForDoor : MonoBehaviour {

    public bool IsActive;

    public Color TargetColor;

    private ParticleSystem _ps;

    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    public Action Finished;

    private Color _color;

    // Use this for initialization
    void Start () {


        _ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {


            // get the particles which matched the trigger conditions this frame
            int numEnter = _ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

            if (numEnter > 0)
            {
                if (enter[0].GetCurrentColor(_ps) == TargetColor)
                {
                    Finished();
                }
            }

            // iterate through the particles which exited the trigger and make them green
            for (int i = 0; i < numEnter; i++)
            {
                ParticleSystem.Particle p = enter[i];
                p.startColor = TargetColor;
                enter[i] = p;
            }

            // re-assign the modified particles back into the particle system
            _ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        }
    
}

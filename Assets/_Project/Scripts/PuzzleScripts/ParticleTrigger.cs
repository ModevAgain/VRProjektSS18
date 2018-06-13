using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParticleTrigger : MonoBehaviour {

    public Action Finished;

    private bool _finished;

    private ParticleSystem _ps;

    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
    }



    void OnParticleTrigger()
    {

        if (!_finished)
        {

            int numEnter = _ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

            if (numEnter > 0)
            {


                Finished();
                _finished = true;
                return;

            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private ParticleSystem _ps;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    private bool _receivedParticle = false;

    public delegate void ParticleReceiver();
    public ParticleReceiver ParticleReceived;

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        _ps.simulationSpace = ParticleSystemSimulationSpace.World;
    }

    void OnParticleTrigger()
    {       
        // get the particles which matched the trigger conditions this frame
        int numEnter = _ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        if (numEnter > 0)
        {
            if (!_receivedParticle)
            {
                _receivedParticle = true;
                Debug.Log("received");
                if (ParticleReceived != null)
                {
                    ParticleReceived();
                }
            }

        }
    }
}

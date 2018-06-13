using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private ParticleSystem _ps;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();


    public delegate void ParticleReceiver();
    public ParticleReceiver ParticleReceived;

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {       
        // get the particles which matched the trigger conditions this frame
        int numEnter = _ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        if (numEnter > 0)
        {
            Debug.Log("yooo");

        }
    }
}

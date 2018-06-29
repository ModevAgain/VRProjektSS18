using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ParticleCollision : MonoBehaviour
{
    private ParticleSystem _ps;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    private bool _receivedParticle = false;

    public delegate void ParticleReceiver();
    public ParticleReceiver ParticleReceived;
    private ReferenceManager _refs;

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        _ps.simulationSpace = ParticleSystemSimulationSpace.World;
        _refs = FindObjectOfType<ReferenceManager>();
    }



    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Goal")
        {
            other.GetComponent<BoxCollider>().enabled = false;
            if (ParticleReceived != null)
            {
                ParticleReceived();
            }
        }
        else if( other.tag == "Mirror")
        {
            VRTK_ControllerHaptics.TriggerHapticPulse(_refs.RightController, 1);
        }
    }
}

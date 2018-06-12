using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

[ExecuteInEditMode]
public class ChangeParticleColor : MonoBehaviour
{
    public ChangeType Type;
    public VRTK_Lever Lever;

    public bool IsActive;

    public Action<ChangeParticleColor> Finished;

    private ParticleSystem _ps;

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    private Color _color;

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();

        if (Type == ChangeType.Lever)
        {
            Lever.ValueChanged += Lever_ValueChanged;
            _color = new Color(1, 0, 0,0.6f);
        }
    }

    private void Lever_ValueChanged(object sender, Control3DEventArgs e)
    {
        float value = 1 - e.normalizedValue / 100;

        _color = new Color(value, 1 - value, 0, 0.6f);

        var mm = _ps.main;

        mm.startColor = _color;

        if (1 - value > 0.99f)
        {
            Finished(this);
            IsActive = true;
        }
    }

    void OnParticleTrigger()
    {
        if (Type == ChangeType.Lever)
            return;

        // get the particles which matched the trigger conditions this frame
        int numEnter = _ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        // iterate through the particles which exited the trigger and make them green
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.startColor = new Color32(0, 255, 0, 255);
            enter[i] = p;
        }

        // re-assign the modified particles back into the particle system
        _ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        if(numEnter > 0)
        {
            IsActive = true;
            Finished(this);
        }

    }


    public enum ChangeType
    {
        Collider,
        Lever
    }

}
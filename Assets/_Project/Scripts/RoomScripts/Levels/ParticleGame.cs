using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ParticleGame : ContentScript {

    public ChangeParticleColor ChangeParticle_Lever;
    public ChangeParticleColor ChangeParticle_Col;
    public ChangeParticleForDoor ChangeParticle_Door;

    public ParticleSystem PS_ForDoor;

    public bool _colFinished;
    public bool _leverFinished;
    private bool _doorOpened;

	// Use this for initialization
	void Start () {

        ChangeParticle_Col.Finished = RegisterFinishedParticleSystem;
        ChangeParticle_Lever.Finished = RegisterFinishedParticleSystem;
        ChangeParticle_Door.Finished = FastForwardGoal;

    }


    private void Update()
    {
        if (_doorOpened)
            return;

        if(_leverFinished && _colFinished)
        {
            _doorOpened = true;
            StartCoroutine(FinishRoom());
        }
    }

    private void FastForwardGoal()
    {
        _doorOpened = true;
        StartCoroutine(FinishRoom());
    }

    public void RegisterFinishedParticleSystem(ChangeParticleColor sender, bool active)
    {
        if (_doorOpened)
            return;

        if (sender == ChangeParticle_Col)
            _colFinished = active;

        if (sender == ChangeParticle_Lever)
            _leverFinished = active;
        
    }

    public IEnumerator FinishRoom()
    {
        _doorOpened = true;

        ParticleSystem.MainModule mm = PS_ForDoor.main;
        mm.startColor = ChangeParticle_Lever.TargetColor;
        yield return new WaitForSeconds(0.5f);
        Door.OpenDoorFromButton();
    }
}

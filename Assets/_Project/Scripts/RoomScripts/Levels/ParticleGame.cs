using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGame : ContentScript {

    public ChangeParticleColor ChangeParticle_Lever;
    public ChangeParticleColor ChangeParticle_Col;

    public ParticleSystem PS_ForDoor;


    private bool _colFinished;
    private bool _leverFinished;
    private bool _doorOpened;

	// Use this for initialization
	void Start () {

        ChangeParticle_Col.Finished = RegisterFinishedParticleSystem;
        ChangeParticle_Lever.Finished = RegisterFinishedParticleSystem;

	}
	



    public void RegisterFinishedParticleSystem(ChangeParticleColor sender)
    {
        if (_doorOpened)
            return;

        if (!_colFinished)
        {
            if (sender == ChangeParticle_Col)
                _colFinished = true;
        }
        if (!_leverFinished)
        {
            if (sender == ChangeParticle_Lever)
                _leverFinished = true;
        }
        if (_leverFinished && _colFinished)
        {
            StartCoroutine(FinishRoom());
        }
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

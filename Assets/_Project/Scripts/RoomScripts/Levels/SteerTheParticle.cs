using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerTheParticle : ContentScript {

    public ParticleCollision PCollision;
    private bool _doorOpened;

	// Use this for initialization
	void Start () {

        PCollision.ParticleReceived += Finish;

	}


    public void Finish()
    {
        if (!_doorOpened)
        {
            _doorOpened = true;
            Door.OpenDoorFromButton();
        }
    }

}

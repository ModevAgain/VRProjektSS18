using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerTheParticle : ContentScript {

    public ParticleTrigger PTrigger;

	// Use this for initialization
	void Start () {

        PTrigger.Finished = Finish;

	}


    public void Finish()
    {
        Door.OpenDoorFromButton();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerEvent : MonoBehaviour {

    public Action Trigger;
    

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {        
            Trigger();
    }
}

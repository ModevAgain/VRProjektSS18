using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChain : MonoBehaviour {

    private ButtonChasers _chaser;

	// Use this for initialization
	void Start () {
        _chaser = GetComponentInParent<ButtonChasers>();
	}


    private void OnTriggerEnter(Collider other)
    {
        _chaser.Trigger(other);
    }


}

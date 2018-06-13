using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGunGame : MonoBehaviour {

    private DoorActivation _door;
    private ParticleCollision _particleCollision;


	// Use this for initialization
	void Start () {
        _door = GetComponentInChildren<DoorActivation>();
        _particleCollision.ParticleReceived = LevelEnd;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LevelEnd()
    {
        _door.OpenDoorFromButton();
    }
}

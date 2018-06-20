using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGunGame : MonoBehaviour {

    private DoorActivation _door;
    private ParticleSystem _ps;
    private ParticleCollision _particleCollision;


	// Use this for initialization
	void Start () {
        _door = GetComponentInChildren<DoorActivation>();
        _ps = GetComponentInChildren<ParticleSystem>();
        _particleCollision = _ps.GetComponent<ParticleCollision>();

        _particleCollision.ParticleReceived += LevelEnd;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LevelEnd()
    {
        Debug.Log("level end");
        _door.OpenDoorFromButton();
    }
}

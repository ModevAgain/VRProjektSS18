using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGunGame : ContentScript {

    private DoorActivation _door;
    private ParticleSystem _ps;
    private ParticleCollision _particleCollision;


	// Use this for initialization
	void Start () {
        
    }

    public override IEnumerator Setup()
    {
        yield return base.Setup();

        _door = GetComponentInChildren<DoorActivation>();
        _ps = GetComponentInChildren<ParticleSystem>();
        _particleCollision = _ps.GetComponent<ParticleCollision>();

        _particleCollision.ParticleReceived += LevelEnd;

    }

    void LevelEnd()
    {
        _door.OpenDoorFromButton();
    }
}

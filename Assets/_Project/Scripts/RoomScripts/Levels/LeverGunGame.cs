using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGunGame : ContentScript {

    public ParticleCollision PCollision;
    private bool _doorOpened;

    // Use this for initialization
    void Start()
    {

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


    //   private DoorActivation _door;
    //   private ParticleSystem _ps;
    //   private ParticleCollision _particleCollision;


    //// Use this for initialization
    //void Start () {

    //   }

    //   public override IEnumerator Setup()
    //   {
    //       yield return base.Setup();

    //       _door = GetComponentInChildren<DoorActivation>();
    //       _ps = GetComponentInChildren<ParticleSystem>();
    //       _particleCollision = _ps.GetComponent<ParticleCollision>();

    //       _particleCollision.ParticleReceived += LevelEnd;

    //   }

    //   void LevelEnd()
    //   {
    //       _door.OpenDoorFromButton();
    //   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SteerTheParticle : ContentScript {

    public ParticleCollision PCollision;
    public Collider ParticleKiller;
    private bool _doorOpened;
    public GameObject ParticleReceiver;
    private Material _receiverMat;
    private bool _dissolved = false;

    // Use this for initialization
    void Start () {

        _receiverMat = ParticleReceiver.GetComponent<MeshRenderer>().material;
        PCollision.ParticleReceived += Finish;
        ParticleKiller.enabled = false;
    }


    public void Finish()
    {
        //StartCoroutine(DissolveReceiver());
        
        if (!_doorOpened)
        {
            ParticleReceiver.SetActive(false);
            _doorOpened = true;
            Door.OpenDoorFromButton();
            ParticleKiller.enabled = true;
        }
    }

    private IEnumerator DissolveReceiver()
    {
        if (!_dissolved)
        {
            _dissolved = true;

            Tween _dissolveRec = _receiverMat.DOFloat(1, "_SliceAmount", 2);

            yield return _dissolveRec.WaitForCompletion();

            Finish();
        }
    }

}

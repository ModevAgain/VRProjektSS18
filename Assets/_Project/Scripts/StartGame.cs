using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;
using DG.Tweening;
using UnityEngine.PostProcessing;

public class StartGame : MonoBehaviour {

    public GameObject Dome;
    public PostProcessingBehaviour PPB;

	// Use this for initialization
	void Start () {

        Dome.GetComponent<Renderer>().material.SetFloat("_DissolveIntensity", 0);
        PPB.profile.vignette.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.Get(OVRInput.Button.One))
        {
            PPB.profile.vignette.enabled = false;

            Dome.GetComponent<Collider>().enabled = false;

            Dome.GetComponent<Renderer>().material.DOFloat(1,"_DissolveIntensity", 3).OnComplete(() =>
            {
                Dome.GetComponent<Renderer>().enabled = false;
            });

        }

    }
}

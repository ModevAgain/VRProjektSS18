using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;
using DG.Tweening;

public class StartGame : MonoBehaviour {

    public GameObject Dome;

	// Use this for initialization
	void Start () {

        Dome.GetComponent<Renderer>().material.SetFloat("_DissolveIntensity", 0);

	}
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.Get(OVRInput.Button.One))
        {

            Dome.GetComponent<Renderer>().material.DOFloat(1,"_DissolveIntensity", 3).OnComplete(() =>
            {
                Dome.GetComponent<Collider>().enabled = false;
                Dome.GetComponent<Renderer>().enabled = false;
            });

        }

    }
}

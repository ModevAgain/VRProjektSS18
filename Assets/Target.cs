using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    TargetController targetCon;

	// Use this for initialization
	void Start () {
        targetCon = GetComponentInParent<TargetController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bullet")
        {
            targetCon.DestroyTarget(gameObject);
        }     
    }
}

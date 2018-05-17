using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using DG.Tweening;

public class Button3D : MonoBehaviour {

    private VRTK_InteractableObject _intObj;

    private void Start()
    {
        _intObj = GetComponent<VRTK_InteractableObject>();
        _intObj.InteractableObjectUsed += _intObj_InteractableObjectUsed;
    }

    private void _intObj_InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        Test();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Test()
    {
        Debug.Log("Geht");
    }
}

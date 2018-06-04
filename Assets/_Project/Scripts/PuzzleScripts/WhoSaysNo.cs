using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoSaysNo : MonoBehaviour {

    public SoundTrigger[] SoundTrigger;

    public DoorActivation Door;

    private bool _saidNo;
    private int _noIndex = -1;

	// Use this for initialization
	void Start () {
		
	}
	
    
    public void ActivateButton(int index)
    {
        if (!_saidNo || index == _noIndex)
        {
            SoundTrigger[index].Play();
            _noIndex = index;
        }
        else Door.OpenDoorFromButton();

        _saidNo = true;

    }

}

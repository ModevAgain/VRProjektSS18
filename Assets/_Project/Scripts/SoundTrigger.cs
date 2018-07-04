using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {

    private AudioSource _src;

	// Use this for initialization
	void Start () {

        _src = GetComponent<AudioSource>();

	}


    public void Play()
    {
        if(!_src.isPlaying)
            _src.Play();
    }

}

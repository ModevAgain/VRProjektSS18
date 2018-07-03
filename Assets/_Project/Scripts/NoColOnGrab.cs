using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class NoColOnGrab : MonoBehaviour {

    public Collider MainCollider;
    private VRTK_InteractableObject _interactable;

	// Use this for initialization
	void Start () {

        _interactable = GetComponent<VRTK_InteractableObject>();
        _interactable.InteractableObjectGrabbed += _interactable_InteractableObjectGrabbed;
        _interactable.InteractableObjectUngrabbed += _interactable_InteractableObjectUngrabbed;

	}

    private void _interactable_InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        MainCollider.enabled = true;
    }

    private void _interactable_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        MainCollider.enabled = false;
    }
}

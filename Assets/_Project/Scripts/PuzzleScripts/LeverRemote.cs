using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class LeverRemote : MonoBehaviour {

    public ControlledObject ControlledObj;

    public GameObject Holder;

    public Action ObjFinishedCallBack;

    private VRTK_Control_UnityEvents controlEvents;

    private void Start()
    {
        GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += LeverRemote_InteractableObjectUngrabbed;
        GetComponent<VRTK_Lever>().ValueChanged += LeverRemote_ValueChanged;
    }

    private void LeverRemote_InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        if (ControlledObj.IsControlledObjectOnTarget())
        {
            GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed -= LeverRemote_InteractableObjectUngrabbed;
            GetComponent<VRTK_Lever>().ValueChanged -= LeverRemote_ValueChanged;
            this.enabled = false;

            ObjFinishedCallBack();
        }
    }

    private void LeverRemote_ValueChanged(object sender, Control3DEventArgs e)
    {
        
        ControlledObj.MoveToNormedPos((e.normalizedValue) / 100);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ReferenceManager : MonoBehaviour {

    public Material DissolveMat;
    public VRTK_ControllerReference LeftController;
    public VRTK_ControllerReference RightController;

    private void Start()
    {
        Invoke("Setup", 1);
    }

    void Setup()
    {
        RightController = VRTK_ControllerReference.GetControllerReference(VRTK_DeviceFinder.GetControllerRightHand());
        LeftController = VRTK_ControllerReference.GetControllerReference(VRTK_DeviceFinder.GetControllerLeftHand());
    }
}

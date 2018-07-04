using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {


    public GameObject Head;

    public GameObject Holder;


    public void Rotate(float angle)
    {
        var v1 = Head.transform.position;
        Holder.transform.RotateAround(v1, Vector3.up, angle);
    }
}

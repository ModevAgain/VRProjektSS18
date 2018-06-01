using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ContentScript : MonoBehaviour {

    public DoorActivation Door;

    public GameObject ConnectionBlock;
    private Material _connectionBlockMat;
    private Collider _connectionBlockCol;

    public virtual void Awake()
    {
        _connectionBlockMat = ConnectionBlock.GetComponent<MeshRenderer>().material;
        _connectionBlockCol = ConnectionBlock.GetComponent<Collider>();
    }

    public IEnumerator CloseConnectionToOldRoom()
    {
        _connectionBlockCol.enabled = true;
        Tween closer =  _connectionBlockMat.DOFloat(0, "_Level", 1);

        yield return closer.WaitForCompletion();
    }

    public virtual IEnumerator Setup()
    {
        _connectionBlockCol.enabled = false;
        _connectionBlockMat.DOFloat(1, "_Level", 0);

        yield return null;
    }
}

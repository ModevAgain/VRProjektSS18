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
        if(ConnectionBlock != null)
        {
            _connectionBlockMat = ConnectionBlock.GetComponent<MeshRenderer>().material;
            _connectionBlockCol = ConnectionBlock.GetComponent<Collider>();
        }

        //foreach (var item in GetComponentsInChildren<VRTK.VRTK_Control>())
        //{
        //    item.DetectSetup();
        //}
    }

    public virtual IEnumerator CloseConnectionToOldRoom()
    {
        _connectionBlockCol.enabled = true;
        yield return new WaitForSeconds(1.5f);
        Tween closer =  _connectionBlockMat.DOFloat(0, "_SliceAmount", 2); 

        yield return closer.WaitForCompletion();
    }

    public virtual IEnumerator Setup()
    {
        _connectionBlockCol.enabled = false;
        _connectionBlockMat.DOFloat(1, "_SliceAmount", 0);

        yield return null;
    }

}

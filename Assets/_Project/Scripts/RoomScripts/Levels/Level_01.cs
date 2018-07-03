using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_01 : ContentScript {

    private void Start()
    {
        GetComponentInChildren<TriggerEvent>().Trigger = () => StartCoroutine(CloseConnectionToOldRoom());
    }



    public override IEnumerator Setup()
    {
        yield return base.Setup();
    }
}

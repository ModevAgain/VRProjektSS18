using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class EndGame : MonoBehaviour
{
    public GameObject Dome;
    public Text Thanks;
    public PostProcessingBehaviour PPB;
    private bool _enabled;

    // Use this for initialization
    void Start()
    {
        Dome.GetComponent<Renderer>().material.SetFloat("_DissolveIntensity", 1);
        Thanks.DOFade(0, 0);
    }

    public IEnumerator StartEndGame()
    {

        if (!_enabled)
            yield break;

        Vector3 targetPos = Camera.main.transform.position;

        targetPos.y = 0;

        transform.DOMove(targetPos, 0);

        Tween dissolver = Dome.GetComponent<Renderer>().material.DOFloat(0, "_DissolveIntensity", 3);

        yield return dissolver.WaitForCompletion();

        PPB.profile.vignette.enabled = true;



        Thanks.DOFade(1, 1);


    }

    public void EnableEndGame()
    {
        _enabled = true;
    }

}

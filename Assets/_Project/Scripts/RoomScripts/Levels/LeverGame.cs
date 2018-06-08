using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LeverGame : ContentScript {

    public Transform Field_Trans;
    public List<ControlledObject> Objs;
    public LeverRemote Lever;

    public Material[] Materials;

    public float LeverHolderStartZ = 1.35f;

    public GameObject Button;

    private List<Renderer> _rens;

    private int _objCount = 0;

	// Use this for initialization
	void Start () {

        

        _rens = new List<Renderer>();

        foreach (var ren in Objs)
        {
            _rens.Add(ren.GetComponent<Renderer>());
        }

        

        foreach(var ren in _rens)
        {
            ren.materials[0] = Materials[0];
            ren.material.DOFloat(1, "_DissolveIntensity", 0);
            ren.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }

        Button.SetActive(false);

        Lever.Holder.transform.DOLocalMoveZ(LeverHolderStartZ, 0);

        Lever.ObjFinishedCallBack = () => StartCoroutine(ObjFinished());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartLeverGame()
    {
        bool doOnce = true;

        foreach (var ren in _rens)
        {
            ren.material.DOFloat(0, "_DissolveIntensity", 2).OnComplete(() =>
            {
                ren.GetComponentInChildren<SpriteRenderer>().enabled = true;
                //ren.materials[1] = Materials[1];
                //ren.materials[1].DOColor(Color.red, 1);

                if (doOnce)
                {
                    Lever.Holder.transform.DOLocalMoveZ(0, 2).OnComplete(() =>
                    {
                        Lever.ControlledObj = Objs[_objCount];
                        Lever.ControlledObj.Selector.Play();
                        Lever.enabled = true;
                    });
                    doOnce = false;
                }

                
            });
        }
    }

    public IEnumerator EndLeverGame()
    {
        Tween dissolver = null;

        foreach (var ren in _rens)
        {
            dissolver  = ren.material.DOFloat(1, "_DissolveIntensity", 2);
        }        

        yield return dissolver.WaitForCompletion();

        Field_Trans.DOLocalMoveX(-4, 2).OnComplete(() =>
        {
            Button.SetActive(true);
            Button.GetComponentInChildren<VRTK.VRTK_Button>().enabled = true;
        });

        
        

    }

    public IEnumerator ObjFinished()
    {


        //Tween doWhite = _rens[_objCount].materials[1].DOColor(Color.white, 0.3f);
        //yield return doWhite.WaitForCompletion();

        Lever.ControlledObj.Selector.Stop();

        yield return null;
        if (_objCount == Objs.Count - 1)
        {
            StartCoroutine(EndLeverGame());
            yield break;
        }

        _objCount++;
        //Tween doRed = _rens[_objCount].materials[1].DOColor(Color.red, 0.3f);
        //yield return doRed.WaitForCompletion();

        Lever.GetComponent<VRTK.VRTK_Lever>().enabled = true;
        Lever.enabled = true;
        Lever.SetNewControlledObj(Objs[_objCount]);
        Lever.ControlledObj.Selector.Play();

    }

    public override IEnumerator Setup()
    {
        yield return base.Setup();


        StartLeverGame();


    }
}

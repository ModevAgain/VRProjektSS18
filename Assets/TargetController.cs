using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

    public GameObject Target;

    private bool _firstStart = true;

    private List<GameObject> _targets = new List<GameObject>();

    private WaitForSeconds _targetRespawnTime;

	// Use this for initialization
	void Start () {
        _targetRespawnTime = new WaitForSeconds(5);
        spawnTargets();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnTargets()
    {
        if (_firstStart)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject tempTarget = Instantiate(Target);
                tempTarget.transform.position = transform.position;

                _targets.Add(tempTarget);
            }
            _firstStart = false;
        }
        else
        {
            GameObject tempTarget = Instantiate(Target);
            tempTarget.transform.position = transform.position;

            _targets.Add(tempTarget);
        }
    }

    private IEnumerator RespawnTarget()
    {
        yield return _targetRespawnTime;

        spawnTargets();        
    }

    public void DestroyTarget(GameObject target)
    {
        _targets.Remove(target);
        Destroy(target);
        StartCoroutine(RespawnTarget());
    }
}

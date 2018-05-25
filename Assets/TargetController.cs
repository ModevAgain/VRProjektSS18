using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {


    public GameObject Target;
    public bool MoveY;
    public bool MoveX;
    public bool MoveZ;

    private bool _firstStart = true;

    private List<GameObject> _targets = new List<GameObject>();

    private WaitForSeconds _targetRespawnTime;
    
	// Use this for initialization
	void Start () {

        _targetRespawnTime = new WaitForSeconds(5);
        
        spawnTargets();
	}
	
    void spawnTargets()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject tempTarget = Instantiate(Target);
            tempTarget.transform.SetParent(transform);
            tempTarget.transform.position = new Vector3(transform.position.x, transform.position.y + (1 * i), transform.position.z);

            _targets.Add(tempTarget);
        }
    }

    void spawnTargets(Vector3 objPos)
    {        
        GameObject tempTarget = Instantiate(Target);
        tempTarget.transform.SetParent(transform);
        tempTarget.transform.position = objPos;
            
        _targets.Add(tempTarget);        
    }


    private IEnumerator RespawnTarget(Vector3 objPos)
    {
        yield return _targetRespawnTime;

        spawnTargets(objPos);        
    }

    public void DestroyTarget(GameObject target)
    {
        _targets.Remove(target);
        Destroy(target);
        StartCoroutine(RespawnTarget(target.transform.position));
    }
}

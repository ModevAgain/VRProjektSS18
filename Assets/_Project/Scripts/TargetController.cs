using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {


    public GameObject Target;
    public int TargetAmount;
    public bool MoveY;
    public bool MoveX;
    public bool MoveZ;
    public int hitCounter;
    public float TargetRespawn;

    public delegate void HitAllTargets();
    public HitAllTargets AllTargetsDestroyed;
    
    private List<GameObject> _targets = new List<GameObject>();

    private WaitForSeconds _targetRespawnTime;
    
	// Use this for initialization
	void Start () {

        _targetRespawnTime = new WaitForSeconds(TargetRespawn);
        
        //spawnTargets();
	}
	
    public void spawnTargets()
    {
        for (int i = 0; i < TargetAmount; i++)
        {
            GameObject tempTarget = Instantiate(Target);
            tempTarget.transform.SetParent(transform);
            tempTarget.transform.position = new Vector3(tempTarget.transform.position.x, tempTarget.transform.position.y + (1 * i), tempTarget.transform.position.z);

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
        hitCounter--;

        spawnTargets(objPos);        
    }

    public void DestroyTarget(GameObject target)
    {
        hitCounter++;
        _targets.Remove(target);
        Destroy(target);
        StartCoroutine(RespawnTarget(target.transform.position));

        if (hitCounter >= TargetAmount)
        {
            if (AllTargetsDestroyed != null)
            {
                AllTargetsDestroyed();
            }
        }
    }

    public void DestroyAllTargets()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}

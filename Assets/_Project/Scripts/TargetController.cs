using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {


    public GameObject Target;
    public int TargetAmount;
    public bool MoveY;
    public bool MoveX;
    public bool MoveZ;
    public int HitCounter;
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
            tempTarget.transform.localPosition = new Vector3(0, (1 * i), 0);

            _targets.Add(tempTarget);
        }
    }

    void spawnTargets(Vector3 objPos)
    {        
        GameObject tempTarget = Instantiate(Target);
        tempTarget.transform.SetParent(transform);

        tempTarget.transform.localPosition = new Vector3 (0, objPos.y, 0);
            
        _targets.Add(tempTarget);
    }


    private IEnumerator RespawnTarget(Vector3 objPos)
    {
        yield return _targetRespawnTime;
        HitCounter--;

        spawnTargets(objPos);
    }

    public void DestroyTarget(GameObject target)
    {
        HitCounter++;
        _targets.Remove(target);
        StartCoroutine(RespawnTarget(target.transform.localPosition));
        Destroy(target);

        if (HitCounter >= TargetAmount)
        {
            DestroyAllTargets();
            
            if (AllTargetsDestroyed != null)
            {
                AllTargetsDestroyed();
            }
        }
    }

    public void DestroyAllTargets()
    {
        foreach (var child in transform.GetComponentsInChildren<Target>())
        {
            child.KillTarget();
        }
        HitCounter = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Target : MonoBehaviour {
    
    private TargetController _targetCon;
    private Level_02 _lvlManager;

    private float _startPos;
    private float _maxMoveRange;
    private bool _hit = false;

    private Tween _targetTweener;

	// Use this for initialization
	void Start () {
        _lvlManager = FindObjectOfType<Level_02>();
        _targetCon = GetComponentInParent<TargetController>();

        //_startPos = transform.parent.position.x;
        _startPos = transform.localPosition.x;

        _maxMoveRange = _startPos + 8;

        MoveTarget();
	}
	
    private void MoveTarget()
    {
        if (!_lvlManager.levelFinished)
        {
            if (_targetCon.MoveY)
               _targetTweener = transform.DOLocalMoveY(Random.Range(_startPos, _maxMoveRange), 3).OnComplete(() => MoveTarget());
            else if (_targetCon.MoveX)
                _targetTweener = transform.DOLocalMoveX(Random.Range(_startPos, _maxMoveRange), 3).OnComplete(() => MoveTarget());
            else if (_targetCon.MoveZ)
                _targetTweener = transform.DOLocalMoveZ(Random.Range(_startPos, _maxMoveRange), 3).OnComplete(() => MoveTarget());
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bullet(Clone)" && !_hit)
        {
            _hit = true;
            _targetTweener.Kill();
            _targetCon.DestroyTarget(gameObject);
        }     
    }

    public void KillTarget()
    {
        _targetTweener.Kill();
        Destroy(gameObject);
    }
}

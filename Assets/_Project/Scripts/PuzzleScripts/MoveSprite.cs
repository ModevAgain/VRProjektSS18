using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveSprite : MonoBehaviour
{

    public Vector3 DesiredPos;

    public void Move()
    {
        transform.DOLocalMove(DesiredPos, 0.5f);
    }

}

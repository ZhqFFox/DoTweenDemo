using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTest : MonoBehaviour
{
    SimpleTween moveTween;
    SimpleTween scaleTween;
    // Start is called before the first frame update
    void Start()
    {
        moveTween = transform.DoMove(new Vector3(10, 10, 10), 3f, EaseType.Linear);
        scaleTween = transform.DoScale(Vector3.one * 10, 3f);

    }


    // Update is called once per frame
    void Update()
    {
        //空格键 终止移动

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SimpleTweenMgr.Kill(moveTween);
        }
        //左Alt键终止缩放
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {

            SimpleTweenMgr.Kill(scaleTween);

        }
    }
}

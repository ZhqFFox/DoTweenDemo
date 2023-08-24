using System;
using UnityEngine;

//扩展管理类
public static class ExpendMgr 
{
    //Transform扩展方法
    public static SimpleTween DoMove(this Transform transform, Vector3 endValue, float duration, EaseType easeType=EaseType.Linear,
                       Action completeCallback = null)
    {
     SimpleTween tween=   SimpleTweenMgr.instance.DoMove(transform, endValue, duration, easeType,completeCallback);

        return tween;
    }

    public static SimpleTween DoScale(this Transform transform, Vector3 endValue, float duration, EaseType easeType = EaseType.Linear,
                   Action completeCallback = null)
    {
        SimpleTween tween = SimpleTweenMgr.instance.DoScale(transform, endValue, duration, easeType, completeCallback);

        return tween;
    }
}

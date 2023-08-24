using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimpleTweenMgr : MonoBehaviour
{
    public static SimpleTweenMgr instance;

    //存储Tween实例
    private List<SimpleTween> tweens;

    private void Awake()
    {
        instance = this;
        tweens = new List<SimpleTween>();
    }

    private void Update()
    {
        for (int i = tweens.Count - 1; i >= 0; i--)
        {
            tweens[i].Update();
        }
    }

   
    public  SimpleTween DoMove(Transform target, Vector3 endValue, float duration, EaseType easeType = EaseType.Linear, Action onComplete = null)
    {
        Vector3 startValue = target.position;
        SimpleTween tween = new SimpleTween(target, startValue, endValue, duration, easeType, onComplete, V3Type.Position);
        tween.Play();
        instance.tweens.Add(tween);
        return tween;
    }

    public  SimpleTween DoScale(Transform target, Vector3 endValue, float duration, EaseType easeType = EaseType.Linear, Action onComplete = null)
    {
        Vector3 startValue = target.localScale;
        SimpleTween tween = new SimpleTween(target, startValue, endValue, duration, easeType, onComplete,V3Type.Scale);
        tween.Play();
        instance.tweens.Add(tween);
        return tween;
    }

    public static void Kill(SimpleTween tween)
    {
        if (instance.tweens.Contains(tween))
        {
            instance.tweens.Remove(tween);
        }
    }
}


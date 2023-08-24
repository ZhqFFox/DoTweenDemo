using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum V3Type
{
    Position,
    Scale
}
public enum EaseType
{
    Linear,
    EaseInSine,
    EaseOutSine,
    EaseInOutSine,
    EaseInBack,
    EaseOutBack,
    EaseInOutBack
}
public class SimpleTween
{
    private Transform target;
    private Vector3 startValue;//开始值
    private Vector3 endValue;//终值
    private float duration;//持续时间
    private float elapsedTime;//已过时间
    private V3Type v3Type;
    private bool isPlaying;
    private EaseType easeType;
    private Action onComplete;//完成回调

    public SimpleTween(Transform target, Vector3 startValue, Vector3 endValue, float duration, EaseType easeType, Action onComplete,V3Type v3type)
    {
        this.target = target;
        this.startValue = startValue;
        this.endValue = endValue;
        this.duration = duration;
        this.easeType = easeType;
        this.onComplete = onComplete;
        this.v3Type = v3type;
    }

    public void Play()
    {
        isPlaying = true;
    }

    public void Update()
    {
        if (!isPlaying)
            return;

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= duration)
        {
            switch (v3Type)
            {
                case V3Type.Position:
                    target.position = endValue;

                    break;
                case V3Type.Scale:
                    target.localScale = endValue;

                    break;
                default:
                    break;
            }
            Complete();
        }
        else
        {
            float t = elapsedTime / duration;
            float easedT = Ease(easeType, t);
            switch (v3Type)
            {
                case V3Type.Position:
                    target.position = Vector3.Lerp(startValue, endValue, easedT);

                    break;
                case V3Type.Scale:
                    target.localScale = Vector3.Lerp(startValue, endValue, easedT);
                    break;
                default:
                    break;
            }
        }
    }

    public void Complete()
    {
        isPlaying = false;
        onComplete?.Invoke();
    }

    private float Ease(EaseType type, float t)
    {
        switch (type)
        {
            case EaseType.Linear:
                return t;
            case EaseType.EaseInSine:
                return Mathf.Sin((t * Mathf.PI) / 2);
            case EaseType.EaseOutSine:
                return 1 - Mathf.Cos((t * Mathf.PI) / 2);
            case EaseType.EaseInOutSine:
                return -(Mathf.Cos(Mathf.PI * t) - 1) / 2;
            case EaseType.EaseInBack:
                float s = 1.70158f;
                return t * t * ((s + 1) * t - s);
            case EaseType.EaseOutBack:
                float s2 = 1.70158f;
                t = t - 1;
                return t * t * ((s2 + 1) * t + s2) + 1;
            case EaseType.EaseInOutBack:
                float s3 = 1.70158f;
                t = t * 2;
                if (t < 1)
                    return (t * t * ((s3 + 1) * t - s3)) / 2;
                else
                {
                    t = t - 2;
                    return (t * t * ((s3 + 1) * t + s3)) / 2 + 1;
                }
            default:
                return t;
        }
    }
}


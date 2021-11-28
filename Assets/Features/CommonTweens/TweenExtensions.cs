using DG.Tweening;
using UnityEngine;

public static class TweenExtensions
{
    public static Tween DORotateAroundAxis(
        this Transform target,
        Vector3 axis,
        float angle,
        float duration,
        Ease ease = Ease.Linear)
    {
        float step = 0;
        float progress = 0;
        Tween t = DOTween.To(
            () => progress, x =>
            {
                step = progress - x;
                progress = x;
            }, angle, duration).SetEase(ease);

        t.OnUpdate(() => { target.RotateAround(target.position, axis, step); });
        t.SetTarget(target);
        return t;
    }
}
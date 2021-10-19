using DG.Tweening;
using UnityEngine;

public static class WaveTween
{
	public static void Tween(Transform obj)
	{
		Sequence sequence = DOTween.Sequence();
		Vector3 startPos = obj.localPosition;
		sequence.Append(obj.DOLocalMove(startPos + new Vector3(0, 0, 0.005f), 1f).SetEase(Ease.InOutQuad));
		sequence.Append(obj.DOLocalMove(startPos, 1f).SetEase(Ease.InOutQuad));
		sequence.SetLoops(-1);
	}
}
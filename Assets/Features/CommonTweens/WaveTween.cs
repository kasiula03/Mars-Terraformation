using DG.Tweening;
using UnityEngine;

public static class WaveTween
{
	public static void Tween(Transform obj)
	{
		Sequence sequence = DOTween.Sequence();
		Vector3 startPos = obj.position;
		sequence.Append(obj.DOMove(startPos + new Vector3(0, 0, 0.5f), 1f).SetEase(Ease.InOutQuad));
		sequence.Append(obj.DOMove(startPos, 1f).SetEase(Ease.InOutQuad));
		sequence.SetLoops(-1);
	}
}
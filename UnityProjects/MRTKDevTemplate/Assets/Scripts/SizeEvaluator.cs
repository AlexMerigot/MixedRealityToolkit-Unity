using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

[Serializable]
public class SizeEvaluator : XRTargetEvaluator
{
    public float minSizeThreshold = 0.1f;
    public float maxSizeThreshold = 1.0f;

    protected override float CalculateNormalizedScore(IXRInteractor interactor, IXRInteractable target)
    {
        Renderer targetRenderer = target.transform.GetComponent<Renderer>();
        if (targetRenderer == null)
        {
            return 0f;
        }
        float size = targetRenderer.bounds.size.magnitude;

        if (size <= minSizeThreshold)
        {
            return 1f;
        }
        else if (size >= maxSizeThreshold)
        {
            return 0f;
        }
        else
        {
            float normalizedSize = (size - minSizeThreshold) / (maxSizeThreshold - minSizeThreshold);
            return 1f - normalizedSize;
        }
    }
}

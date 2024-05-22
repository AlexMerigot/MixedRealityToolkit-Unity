// using System;
// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;
// using UnityEngine.XR.Interaction.Toolkit.Filtering;

// [Serializable]
// public class SizeEvaluator : XRTargetEvaluator
// {
//     public float minSizeThreshold = 0.1f; // The size at which the object gets the highest score
//     public float maxSizeThreshold = 1.0f; // The size at which the object gets the lowest score

//     protected override float CalculateNormalizedScore(IXRInteractor interactor, IXRInteractable target)
//     {
//         // Calculate the size of the target object (using the bounding box)
//         Renderer targetRenderer = target.transform.GetComponent<Renderer>();
//         if (targetRenderer == null)
//         {
//             // If no renderer is found, we cannot evaluate size, so return the lowest score
//             return 0f;
//         }

//         // Get the bounds size (we can use magnitude of the bounds extents as a simple size measure)
//         float size = targetRenderer.bounds.size.magnitude;

//         // Normalize the size to a score between 0 and 1
//         if (size <= minSizeThreshold)
//         {
//             return 1f;
//         }
//         else if (size >= maxSizeThreshold)
//         {
//             return 0f;
//         }
//         else
//         {
//             // Linearly interpolate between minSizeThreshold and maxSizeThreshold
//             return 1f - (size - minSizeThreshold) / (maxSizeThreshold - minSizeThreshold);
//         }
//     }
// }

using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

[Serializable]
public class SizeEvaluator : XRTargetEvaluator
{
    public float minSizeThreshold = 0.1f; // La taille à laquelle l'objet obtient le score le plus élevé
    public float maxSizeThreshold = 1.0f; // La taille à laquelle l'objet obtient le score le plus bas

    protected override float CalculateNormalizedScore(IXRInteractor interactor, IXRInteractable target)
    {
        // Calculer la taille de l'objet cible (en utilisant la boîte englobante)
        Renderer targetRenderer = target.transform.GetComponent<Renderer>();
        if (targetRenderer == null)
        {
            // Si aucun renderer n'est trouvé, nous ne pouvons pas évaluer la taille, donc retournez le score le plus bas
            return 0f;
        }

        // Obtenir la taille des bounds (nous pouvons utiliser la magnitude des extents des bounds comme mesure de la taille)
        float size = targetRenderer.bounds.size.magnitude;

        // Normaliser la taille en un score entre 0 et 1
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
            // Interpoler linéairement entre minSizeThreshold et maxSizeThreshold
            float normalizedSize = (size - minSizeThreshold) / (maxSizeThreshold - minSizeThreshold);
            return 1f - normalizedSize;
        }
    }
}

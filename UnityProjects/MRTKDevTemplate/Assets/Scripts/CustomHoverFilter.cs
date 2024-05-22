using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class CustomHoverFilter : IXRHoverFilter
{
    public bool canProcess => true;
    public bool Process(IXRHoverInteractor interactor, IXRHoverInteractable interactable)
    {
        return interactable.transform.CompareTag("Hoverable");
    }
}

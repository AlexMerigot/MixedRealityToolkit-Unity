using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class CustomSelectFilter : MonoBehaviour, IXRSelectFilter
{
    public bool canProcess => true;
    public bool Process(IXRSelectInteractor interactor, IXRSelectInteractable interactable)
    {
        return interactable.transform.CompareTag("Hoverable");
    }
}

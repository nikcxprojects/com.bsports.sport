using UnityEngine.EventSystems;
using UnityEngine;

public class InteractionArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool IsPressing { get; set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsPressing = false;
    }

    private void OnDisable()
    {
        IsPressing = false;
    }
}

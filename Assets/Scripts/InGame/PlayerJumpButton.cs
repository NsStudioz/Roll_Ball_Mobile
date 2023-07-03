using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerJumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public static event Action OnButtonClickDown;
    public static event Action OnButtonClickUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnButtonClickDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnButtonClickUp?.Invoke();
    }
}

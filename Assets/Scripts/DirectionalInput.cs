using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class DirectionalInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Key key;
    public Image image;
    public Color normalColor = Color.white;
    public Color pressColor = Color.gray;

    public void OnPointerEnter(PointerEventData eventData)
    {
        var keyboardState = new KeyboardState();
        keyboardState.Press(key);
        InputSystem.QueueStateEvent(Keyboard.current, keyboardState);
        if (image)
        {
            image.color = pressColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var keyboardState = new KeyboardState();
        keyboardState.Release(key);
        InputSystem.QueueStateEvent(Keyboard.current, keyboardState);
        if (image)
        {
            image.color = normalColor;
        }
    }
}

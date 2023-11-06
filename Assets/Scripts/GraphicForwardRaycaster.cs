using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GraphicForwardRaycaster : GraphicRaycaster
{
    [Header("Event Forwarding")]
    [SerializeField] private RectTransform _viewport;
    [SerializeField] private GraphicRaycaster _forwardRaycaster;

    private Canvas _canvas;
    private Canvas _forwardCanvas;

    protected override void Start()
    {
        base.Start();
        UpdateCanvasReferences();
    }

    public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
    {
        if (_forwardRaycaster
            && RectTransformUtility.ScreenPointToLocalPointInRectangle(_viewport, eventData.position, _canvas.worldCamera, out Vector2 localPosition)
            && _viewport.rect.Contains(localPosition))
        {
            Vector2 normalizedPositionInViewportRect = Rect.PointToNormalized(_viewport.rect, localPosition);
            Vector2 forwardedPosition = normalizedPositionInViewportRect * _forwardCanvas.pixelRect.size;
            eventData.position = forwardedPosition;
            _forwardRaycaster.Raycast(eventData, resultAppendList);
        }
        else
        {
            base.Raycast(eventData, resultAppendList);
        }
    }

    private void UpdateCanvasReferences()
    {
        if (_forwardRaycaster)
        {
            _canvas = GetComponent<Canvas>();
            _forwardCanvas = _forwardRaycaster.GetComponent<Canvas>();
        }
    }
}

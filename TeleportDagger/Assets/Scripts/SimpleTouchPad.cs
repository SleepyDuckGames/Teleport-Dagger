using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IBeginDragHandler
{
    private Vector2 origin;
    private Vector2 direction;
    private bool cleek;
    public bool Cleek
    {
        get { return cleek; }
        set { cleek = value; }
    }
    private bool swipeUp;
    public bool SwipeUp
    {
        get { return swipeUp; }
        set { swipeUp = value; }
    }
    private bool swipeDown;
    public bool SwipeDown
    {
        get { return swipeDown; }
        set { swipeDown = value; }
    }

    private void Awake()
    {
        direction = Vector2.zero;
        cleek = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        origin = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPosition = eventData.position;
        Vector2 directionRaw = currentPosition - origin;
        direction = directionRaw.normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector2.zero;
        cleek = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.y) > Mathf.Abs(eventData.delta.x))
        {
            if(eventData.delta.y > 0)
            {
                swipeUp = true;
            }
            else
            {
                swipeDown = true; 
            }
        }
    }

    public Vector2 GetDirection()
    {
        return direction;
    }
}

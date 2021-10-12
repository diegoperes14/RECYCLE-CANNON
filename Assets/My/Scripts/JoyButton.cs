using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData) {
        pressed = true;
        }
    [HideInInspector]
    protected bool pressed;
    public void OnPointerUp(PointerEventData eventData) {
        pressed = false;
        }
    }

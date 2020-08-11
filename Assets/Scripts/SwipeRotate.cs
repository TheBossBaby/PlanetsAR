using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class SwipeRotate : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotY;
    public float rotateSpeedModifier = 0.1f;
    
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                rotY = Quaternion.Euler(0f, - touch.deltaPosition.x * rotateSpeedModifier, 0f);
                transform.rotation = rotY * transform.rotation;
            }
        }

    }
}
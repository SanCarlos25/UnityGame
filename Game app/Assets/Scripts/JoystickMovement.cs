using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMovement : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBackground;
    public Vector2 joystickVector;
    private Vector2 joystickTouchPosition;
    private Vector2 joystickOrignialPosition;
    private float joystickRadius;

    // Start is called before the first frame update
    void Start()
    {
        // assigning joystick original position 
        joystickOrignialPosition = joystickBackground.transform.position;
        // assigning joystick radius
        joystickRadius = joystickBackground.GetComponent<RectTransform>().sizeDelta.y / 8;
    }

    // called when user touches screen
    public void PointerDown()
    {
        // moves joystick to the position of users finger
        // the user can touch anywhere on the sceen and the joystick will follow
        joystick.transform.position = Input.mousePosition;
        joystickBackground.transform.position = Input.mousePosition;
        joystickTouchPosition = Input.mousePosition;
    }

    // called when user drags finger on screen
    public void Drag(BaseEventData baseEventData)
    {
        // get drag position
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPosition = pointerEventData.position;
        joystickVector = (dragPosition - joystickTouchPosition).normalized;

        float joystickDistance = Vector2.Distance(dragPosition, joystickTouchPosition);

        // makes sure the joystick only moves within the joystick background
        if(joystickDistance < joystickRadius)
        {
            joystick.transform.position = joystickTouchPosition + joystickVector * joystickDistance;
        }
        else
        {
            joystick.transform.position = joystickTouchPosition + joystickVector * joystickRadius;
        }
    }
    // called when user is no longer touching the screen
    public void PointerUp()
    {
        // set to 0 so the player doesnt continue moving when the user is no longer touching the screen
        joystickVector = Vector2.zero;
        // set joystick and joystick background back to its original position
        joystick.transform.position = joystickOrignialPosition;
        joystickBackground.transform.position = joystickOrignialPosition;
    }


}

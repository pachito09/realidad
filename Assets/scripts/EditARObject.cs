using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.ARFoundation;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class EditARObject : MonoBehaviour
{
    [SerializeField] private ARRaycastManager aRRaycastManager;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }
    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
    public void Update()
    {
        if (Touch.activeTouches.Count == 1)
        {

            if (Touch.activeTouches.Count > 0)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                Touch touch = Touch.activeTouches[0];

                if (touch.phase == TouchPhase.Began)
                {
                    List<ARRaycastHit> hits = new List<ARRaycastHit>();
                    if (aRRaycastManager.Raycast(touch.screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                    {
                        Pose pose = hits[0].pose;
                        GameManager.Instance.currObject.transform.position = pose.position;
                    }
                }
            }
        }
        else if (Touch.activeTouches.Count == 2)
        {
            Touch touchZero = Touch.activeTouches[0];
            Touch touchOne = Touch.activeTouches[1];
            if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
            {
                Vector2 touchZeroPrevPosition = touchZero.screenPosition - touchZero.delta;
                Vector2 touchOnePrevPosition = touchOne.screenPosition - touchOne.delta;

                float prevAngle = Mathf.Atan2(touchOnePrevPosition.y - touchOnePrevPosition.y, touchOnePrevPosition.x - touchOnePrevPosition.x);
                float currAngle = Mathf.Atan2(touchZero.screenPosition.y - touchOne.screenPosition.y, touchZero.screenPosition.x - touchOne.screenPosition.x);

                float deltaAngle = Mathf.DeltaAngle(prevAngle, currAngle);
                GameManager.Instance.currObject.transform.Rotate(Vector3.up, deltaAngle, Space.World); 
            }
        }
    }
}

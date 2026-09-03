using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceCube : MonoBehaviour
{
    [SerializeField] private ARRaycastManager aRRaycastManager;

    private bool isPlacing = false;

    private void Update()
    {
        if (GameManager.Instance.appStates == AppStates.InInventoryMenu)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Toco en la UI");
                return;
            }

            var touchscreen = Touchscreen.current;

            if (touchscreen.touches[0].isInProgress && !isPlacing)
            {

                var touch0 = touchscreen.touches[0];
                if (touch0.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
                {
                    Vector3 touchPos = touch0.position.ReadValue();
                    PlaceObject(touchPos);
                }
            }
        }
    }
    private void PlaceObject(Vector3 touchPosition)
    {
        var rayHits = new List<ARRaycastHit>();

        aRRaycastManager.Raycast(touchPosition, rayHits, TrackableType.PlaneWithinPolygon);
        if (rayHits.Count > 0 && GameManager.Instance.selectedObject != null)
        {
            StartCoroutine(WaitPlace());
            Vector3 spawnPosition = rayHits[0].pose.position;
            Quaternion spawnRotation = rayHits[0].pose.rotation;
            GameManager.Instance.currObject = Instantiate(GameManager.Instance.selectedObject, spawnPosition, spawnRotation);
            GameManager.Instance.EditMenu();
        }
    }

    IEnumerator WaitPlace()
    {
        isPlacing = true;
        yield return new WaitForSeconds(1f);
        isPlacing = false;
    }
}
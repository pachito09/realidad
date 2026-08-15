using System.Collections;
using System.Collections.Generic;
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
        var touchscreen = Touchscreen.current;

        if (touchscreen.touches[0].isInProgress && !isPlacing)
        {

            var touch0 = touchscreen.touches[0];
            if (touch0.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
            {
                Vector2 touchPos = touch0.position.ReadValue();
                PlaceObject(touchPos);
            }
        }
    }
    private void PlaceObject(Vector2 touchPosition)
    {
        var rayHits = new List<ARRaycastHit>();

        aRRaycastManager.Raycast(touchPosition, rayHits, TrackableType.AllTypes);
        if (rayHits.Count > 0)
        {
            StartCoroutine(WaitPlace());
            Vector3 spawnPosition = rayHits[0].pose.position;
            Quaternion spawnRotation = rayHits[0].pose.rotation;
            Instantiate(aRRaycastManager.raycastPrefab, spawnPosition, spawnRotation);
        }
    }
    IEnumerable WaitPlace()
    {
        isPlacing = true;
        yield return new WaitForSecondsRealtime(1f);
        isPlacing = false;
    }
}
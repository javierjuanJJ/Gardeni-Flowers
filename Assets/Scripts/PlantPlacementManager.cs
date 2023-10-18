using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Random = UnityEngine.Random;

public class PlantPlacementManager : MonoBehaviour
{
    [SerializeField] private GameObject[] flowers;

    [SerializeField] private ARSessionOrigin sessionOrigin;

    [SerializeField] private ARRaycastManager raycastManager;

    [SerializeField] private ARPlaneManager planeManager;

    private List<ARRaycastHit> _raycastHits;

    private void Awake()
    {
        _raycastHits = new List<ARRaycastHit>();
    }

    private void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            bool collision = raycastManager.Raycast(Input.mousePosition, _raycastHits, TrackableType.PlaneWithinPolygon);

            if (collision)
            {
                GameObject _object = Instantiate(flowers[Random.Range(0, flowers.Length - 1)]);
                _object.transform.position = _raycastHits[0].pose.position;
            }

            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }

            planeManager.enabled = false;

        }
    }
}

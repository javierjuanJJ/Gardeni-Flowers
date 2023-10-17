using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class PlantPlacementManager : MonoBehaviour
{
    [SerializeField] private GameObject[] flowers;

    [SerializeField] private ARSessionOrigin sessionOrigin;

    [SerializeField] private ARRaycastManager raycastManager;

    [SerializeField] private ARPlaneManager planeManager;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject arTree;
    [SerializeField] private Camera arCamera;
    [SerializeField] ARRaycastManager raycastManager;

    List<ARRaycastHit> hitList = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            if(raycastManager.Raycast(ray, hitList))
            {
                Pose pose = hitList[0].pose;
                Instantiate(arTree, pose.position, pose.rotation);
            }
        }
    }
}

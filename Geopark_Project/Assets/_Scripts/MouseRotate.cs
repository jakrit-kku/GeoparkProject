using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseRotate : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector3 scollZoomSpeed;
    [SerializeField] float clampZMin;
    [SerializeField] float clampZMax;
    private Vector3 previousPos;



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            // prevent rot when over UI
            if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Vector3 direction = previousPos - cam.ScreenToViewportPoint(Input.mousePosition);
            cam.transform.position = new Vector3();

            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y*180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x*180, Space.World);
            cam.transform.Translate(offset);

            previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.mouseScrollDelta.y > 0)  // mouse up
        {
            offset -= scollZoomSpeed;
        }
        if (Input.mouseScrollDelta.y < 0)  // mouse down
        {
            offset += scollZoomSpeed;
        }
        offset.z = Mathf.Clamp(offset.z, clampZMin, clampZMax);  // clamp z value

        cam.transform.position = new Vector3();
        cam.transform.Translate(offset);
        previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
    }

    public void setNewOffset(Vector3 newOffset)
    {
        offset = newOffset;

        cam.transform.position = new Vector3();
        cam.transform.Translate(offset);
        previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
    }

}

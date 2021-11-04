using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector3 scollZoomSpeed;
    private Vector3 previousPos;



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
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
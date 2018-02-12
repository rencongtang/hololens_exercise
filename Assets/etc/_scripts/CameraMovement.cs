using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement

// for using the mouse displacement for calculating the amount of camera movement and panning code.
public class CameraMovement : MonoBehaviour
{
    // Variables

    public float turnSpeed = 1.0f; // Speed of movement of the camera along an axis
    public float panSpeed = 1.0f; // Speed of canera when being panned
    public float zoomSpeed = 1.0f; // Speed of camera goes forth and back

    private Vector3 mouseOrigin; // Position of mouse when dragging begins 
    private bool isPanning; // Judge if the camera is being panning or not 
    private bool isRotating; // Judge if the camera being rotated or not
    private bool isZooming; // Judge if the camera being Zoomed or not


    // Update
    void Update()
    {
        Debug.Log(Input.mousePosition);
        // Get the lest mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        // Get the right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            // Get the mouse position 
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }

        // Get the middle mouse button
        if (Input.GetMouseButtonDown(2))
        {
            mouseOrigin = Input.mousePosition;
            isZooming = true;
        }

        // Disable movements when the button is not pressed
        if (Input.GetMouseButtonUp(0)) isRotating = false;
        if (Input.GetMouseButtonUp(1)) isPanning = false;
        if (Input.GetMouseButtonUp(2)) isZooming = false;

        if (isRotating)
        {
            // @ Mario: the ScreenToViewportPoint is a function that to transfer the position on the screen to world space.
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
            transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
        }

        if (isPanning)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
            Debug.Log("Panning");
            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, pos.z * panSpeed);
            transform.Translate(move, Space.Self);
        }

        if (isZooming)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
            Debug.Log("Panning");
            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, pos.z * panSpeed);
            transform.Translate(move, Space.Self);
        }
    }
}


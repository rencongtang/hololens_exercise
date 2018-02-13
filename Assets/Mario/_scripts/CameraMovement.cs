using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement

// for using the mouse displacement for calculating the amount of camera movement and panning code.
public class CameraMovement : MonoBehaviour
{
    // Variables

    public float turnSpeed = 6.0f; // Speed of movement of the camera along an axis
    public float panSpeed = 6.0f; // Speed of canera when being panned
    public float zoomSpeed = 6.0f; // Speed of camera goes forth and back
    public float moveSpeed = 6.0f; // Speed of camera when being moved via inpiut keyboard 

    private Vector3 mouseOrigin; // Position of mouse when dragging begins 
    private bool isPanning; // Judge if the camera is being panning or not 
    private bool isRotating; // Judge if the camera being rotated or not
    private bool isZooming; // Judge if the camera being Zoomed or not
    private float hMove; // The movement of horizaontal
    private float vMove; // The movement of vertical
    private Vector3 move; // The movement vector


    // Update
    void Update()
    {
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

        Rotating();
        Panning();
        Zooming();
        Move();
    }

    void Rotating()
    {
        if (isRotating)
        {
            // @ Mario: the ScreenToViewportPoint is a function that to transfer the position on the screen to world space.
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
            transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed * 10);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed * 10);
            // @ Mario: this setp makes the movement of camera keep stable, without the code below, the camera will keep moving until the user release the mouse button
            mouseOrigin = Input.mousePosition;
        }
    }

    void Panning()
    {
        if (isPanning)
        {
            // @ Mario: the ScreenToViewportPoint is a function that to transfer the position on the screen to world space.
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, pos.z * panSpeed);
            transform.Translate(move, Space.Self);
            // @ Mario: this setp makes the movement of camera keep stable, without the code below, the camera will keep moving until the user release the mouse button
            mouseOrigin = Input.mousePosition;
        }
    }

    void Zooming()
    {

        if (isZooming)
        {
            // @ Mario: the ScreenToViewportPoint is a function that to transfer the position on the screen to world space.
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
            Vector3 move = pos.y * zoomSpeed * transform.forward;
            transform.Translate(move, Space.World);
            // @ Mario: this setp makes the movement of camera keep stable, without the code below, the camera will keep moving until the user release the mouse button
            mouseOrigin = Input.mousePosition;
        }
    }

    void Move()
    {
        hMove = Input.GetAxisRaw("Horizontal");
        vMove = Input.GetAxisRaw("Vertical");
        move.Set(hMove, 0f, vMove);
        // @ Mario: the function eulerAngles can detedt the rotation angle comparing to the global axis. Reference: http://blog.csdn.net/lyh916/article/details/45952517
        Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
        float y = Camera.main.transform.rotation.eulerAngles.y;
        // @ Mario: Quaterion returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis.
        // movement = Quaternion.Euler(rotation) * movement; // This movement will not lock the movement on y axis.
        move = Quaternion.Euler(0, y, 0) * move.normalized; // This movemenrt will lovk the movement on y axis.
        Vector3 movement = move.normalized * moveSpeed * Time.deltaTime;
        transform.position += movement;

    }

}


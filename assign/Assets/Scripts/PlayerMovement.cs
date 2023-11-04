using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private CharacterController Controller;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;


    void Update()
    {

        PlayerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        // Check if the right mouse button is held down to enable camera rotation
        if (Input.GetMouseButton(1))
        {
            PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            MovePlayerCamera();
        }
        else
        {
            // Reset mouse input if right mouse button is not held.
            PlayerMouseInput = Vector2.zero; 
        }

        MovePlayer();
    }
    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);
        if (Input.GetKey(KeyCode.Space))
        {
            Velocity.y = 1f;

        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {

            Velocity.y = -1f;

        }
        Controller.Move(MoveVector*Speed*Time.deltaTime);
        Controller.Move(Velocity*Speed*Time.deltaTime);

        Velocity.y = 0f;


    }

    private void  MovePlayerCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;
        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }


}


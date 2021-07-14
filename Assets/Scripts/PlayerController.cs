using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cameraMain;
    [SerializeField] private CharacterController characterController;

    [SerializeField] private float sensetiveMouse = 9f;
    [SerializeField] private float speed = 6f;

    [SerializeField] private float minMaxVert = 60f;
    private float rotationX = 0;



    private void OnEnable()
    {
        InputsManager.OnCharacterMove += MoveCharacter;
        InputsManager.OnRotateCharacterY += RotateAroundY;
        InputsManager.OnRotateCharacterX += RotateAroundX;
    }

    private void OnDisable()
    {
        InputsManager.OnCharacterMove -= MoveCharacter;
        InputsManager.OnRotateCharacterY -= RotateAroundY;
        InputsManager.OnRotateCharacterX -= RotateAroundX;
    }


    private void MoveCharacter(Vector3 movement)
    {
        movement *= speed;
        movement = Vector3.ClampMagnitude(movement, speed);

        movement = transform.TransformDirection(movement * Time.deltaTime);
        characterController.Move(movement);
    }


    private void RotateAroundY(float angel)
    {
        float delta = angel * sensetiveMouse;
        float rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(0, rotationY, 0);
    }


    private void RotateAroundX(float angel)
    {
        rotationX -= angel * sensetiveMouse;
        rotationX = Mathf.Clamp(rotationX, -minMaxVert, minMaxVert);

        cameraMain.transform.localEulerAngles = new Vector3(rotationX, 0, 0);
    }
}

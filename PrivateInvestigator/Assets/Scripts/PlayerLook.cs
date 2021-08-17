using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float sensitivity = 40.0f;
    private float playerXRotation = 0.0f;
    private float rotationRange = 55.0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        PlayerLookAround();
    }

    private void PlayerLookAround()
    {
        float playerAxisX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float playerAxisY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        playerXRotation -= playerAxisY;
        playerXRotation = Mathf.Clamp(playerXRotation, -rotationRange, rotationRange);

        transform.parent.Rotate(Vector3.up * playerAxisX);
        transform.localRotation = Quaternion.Euler(playerXRotation, 0.0f, 0.0f);
    }
}

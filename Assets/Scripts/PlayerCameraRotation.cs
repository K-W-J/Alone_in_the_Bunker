using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRotation : MonoBehaviour
{
    private float MouseDirX;
    private float MouseDirY;
    private Vector3 startMouseDir;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

    }

    public void MouseRotation(float mouseDirX, float mouseDirY)
    {
        MouseDirX += mouseDirX * 100 * Time.deltaTime;
        MouseDirY += mouseDirY * 100 * Time.deltaTime;

        MouseDirY = Mathf.Clamp(MouseDirY, -80, 90);

        Vector3 MoveDir = new Vector3(-MouseDirY, MouseDirX, 0);

        MoveDir = Vector3.Lerp(startMouseDir, MoveDir, Time.deltaTime * 5);

        transform.localEulerAngles = MoveDir;

        startMouseDir = MoveDir;
    }
}

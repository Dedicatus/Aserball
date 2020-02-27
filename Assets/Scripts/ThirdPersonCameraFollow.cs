using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraFollow : MonoBehaviour
{
    //Determines the limitations of vertical camera movement
    [SerializeField] private float Y_ANGLE_MIN = 15.0f;
    [SerializeField] private float Y_ANGLE_MAX = 25.0f;

    public Transform character; //What the camera is looking at..the main character

    [SerializeField] private float distance = -5.0f; // Distance to stay from character, Make sure it is negative
    [SerializeField] private float offsetY = 2.5f;
    [SerializeField] private float xRotationSpeed = 2.5f;
    [SerializeField] private float yRotationSpeed = 2.5f;
    private float currentX = 0.0f; // Holds value of X mouse movement
    private float currentY = 0.0f; // Holds value of Y mouse movement

    void start()
    {
        character = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (character == null)
        {
            character = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal_R")) > 0.19f || Mathf.Abs(Input.GetAxis("Vertical_R")) > 0.19f)
        {
            currentX += Input.GetAxis("Horizontal_R") * Time.deltaTime * xRotationSpeed;
            currentY += Input.GetAxis("Vertical_R") * Time.deltaTime * yRotationSpeed;
        }

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    void LateUpdate()
    {                                                        //Rotation around character............/...Keeps distance from character          
        gameObject.transform.position = character.position + Quaternion.Euler(currentY+10f, currentX , 0) * new Vector3(0, 0, distance);
        gameObject.transform.LookAt(character.position + new Vector3(0, offsetY, 0));//Points camera at character
        character.gameObject.GetComponent<Player>().changeCameraY(gameObject.transform.localEulerAngles.y);
    }
}

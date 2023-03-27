using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour :MonoBehaviour {
    [SerializeField] GameObject cam;
    [SerializeField] GameObject camBody;

    [SerializeField] int mouseSensitivity = 500;
    [SerializeField] int sprintSpeed = 5;
    int movementSpeed = 1;

    float mouseX;
    float mouseY;

    void Start() {
    
        cam = Camera.main.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        camBody.transform.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);
        cam.transform.Rotate(Vector3.right * -mouseY * mouseSensitivity * Time.deltaTime);

        if (Input.GetKey(KeyCode.W)) {
            camBody.transform.Translate(camBody.transform.forward * movementSpeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey(KeyCode.S)) {
            camBody.transform.Translate(-camBody.transform.forward * movementSpeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey(KeyCode.D)) {
            camBody.transform.Translate(camBody.transform.right * movementSpeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey(KeyCode.A)) {
            camBody.transform.Translate(-camBody.transform.right * movementSpeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey(KeyCode.Space)) {
            camBody.transform.Translate(camBody.transform.up * movementSpeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey(KeyCode.LeftControl)) {
            camBody.transform.Translate(-camBody.transform.up * movementSpeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            camBody.transform.position = new Vector3(camBody.transform.position.x,0.0f,camBody.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            movementSpeed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            movementSpeed = 1;
        }
    }
}
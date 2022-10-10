using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    [SerializeField] float sensivity = 100f;
    [SerializeField] Transform playerBody;
    float rotationX = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    
    void Update()
    {
        float Xmouse = Input.GetAxis("Mouse X")* sensivity * Time.deltaTime;
        float Ymouse = Input.GetAxis("Mouse Y")* sensivity * Time.deltaTime;

        rotationX -= Ymouse;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);


        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * Xmouse);


        
    }
}

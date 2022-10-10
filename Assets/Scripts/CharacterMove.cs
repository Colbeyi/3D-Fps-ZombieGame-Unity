using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 12f;
    Vector3 velocity;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] bool isGrounded;
    [SerializeField] Transform checkGround;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] float jumpHeight = 10f;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(checkGround.position,groundDistance,groundLayerMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x+ transform.forward * y;
        controller.Move(move*speed*Time.deltaTime);
        
        velocity.y += gravity*Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}

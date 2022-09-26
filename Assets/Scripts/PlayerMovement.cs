using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed;

	public Transform orientation;

	float horizontalInput;
	float verticalInput;

	Vector3 moveDirection;

	Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
	}

	private void Update()
    {
		MyInput();
		//SpeedControl();
		//rb.drag = 5;
    }

	private void FixedUpdate()
    {
		MovePlayer();
    }

	private void MyInput()
    {
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");
    }

	private void MovePlayer()
    {
		moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

		rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }

	private void SpeedControl()
    {
		Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

		if(flatVel.magnitude > moveSpeed)
        {
			Vector3 limitedVel = flatVel.normalized * moveSpeed;
			rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
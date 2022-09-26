using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceManager : MonoBehaviour
{
	private Rigidbody rb;
	private Vector3 bounceForce;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("BouncyObstacle"))
		{
			bounceForce = new Vector3(1000f, 1000f, 1000f);
			rb.AddForce(bounceForce);
		}
	}
}

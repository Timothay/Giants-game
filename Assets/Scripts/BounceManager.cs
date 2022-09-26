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
			bounceForce = new Vector3(Random.Range(-1000.0f, 1000.0f), Random.Range(0f, 100.0f), Random.Range(-1000.0f, 1000.0f));
			rb.AddForce(bounceForce);
		} else if (other.gameObject.CompareTag("Pickable"))
        {
			other.gameObject.GetComponent<BoxCollider>().enabled = false;
			other.gameObject.GetComponent<MeshRenderer>().enabled = false;

			GameObject.Find("ScoreText").GetComponent<ScoreManager>().score += 1;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("BouncyObstacle"))
		{
			bounceForce = new Vector3(Random.Range(-1000.0f, 1000.0f), Random.Range(0f, 200.0f), Random.Range(-1000.0f, 1000.0f));
			rb.AddForce(bounceForce);
		}
	}
}

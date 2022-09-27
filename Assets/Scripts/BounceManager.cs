using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceManager : MonoBehaviour
{
	private Rigidbody rb;
	private int currentPosition;
	private Vector3 bounceForce;
	public AudioClip[] bounceSounds;
	public AudioClip pickupSound;
	public AudioSource audioSource;
	public AudioListener audioListener;
	private Vector3[] positions = new Vector3[9] { new Vector3(-45f, 0.1f, -10f), new Vector3(-77f, 0.1f, -34f), new Vector3(20f, 0.1f, -34f), new Vector3(75f, 0.1f, -8f), new Vector3(62.5f, 0.1f, -2f), new Vector3(55f, 0.1f, 43.5f), new Vector3(50f, 0.1f, -63f), new Vector3(-96f, 0.1f, -95f), new Vector3(-60f, 0.1f, -55f) };
	public GameObject bananaPrefab;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		currentPosition = 0;

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("BouncyObstacle"))
		{
			PlayRandom();
			bounceForce = new Vector3(Random.Range(-1000.0f, 1000.0f), Random.Range(0f, 100.0f), Random.Range(-1000.0f, 1000.0f));
			rb.AddForce(bounceForce);
		} else if (other.gameObject.CompareTag("Pickable"))
        {
			audioSource.clip = pickupSound;
			audioSource.Play();
			currentPosition += 1;
			if (currentPosition == 9)
            {
				currentPosition = 0;
            }
			other.gameObject.GetComponent<BoxCollider>().enabled = false;
			other.gameObject.GetComponent<MeshRenderer>().enabled = false;
			GameObject newBanana = Instantiate(bananaPrefab, positions[currentPosition], Quaternion.identity);
			GameObject.Find("ScoreText").GetComponent<ScoreManager>().score += 1;
		}
	}
	void PlayRandom()
    {
		audioSource.clip = bounceSounds[Random.Range(0, bounceSounds.Length)];
		audioSource.Play();
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

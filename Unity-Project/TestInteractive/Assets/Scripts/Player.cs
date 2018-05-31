using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody rb;
	private float speed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		speed = 10;
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");



        Vector3 movement1 = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement1 * speed);


		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}

	}

	public void Jump()
	{
		Vector3 movement = new Vector3(0, 1, 0);
		rb.AddForce(300.0F * movement);
		//sound1.Play();
	}
}

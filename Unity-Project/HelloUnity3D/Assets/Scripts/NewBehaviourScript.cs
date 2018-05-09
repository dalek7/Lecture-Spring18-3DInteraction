using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    //private Joystick joystick;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        speed = 10;
        //joystick = FindObjectOfType<Joystick>();

    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown("z"))
            rb.angularDrag = 5.0F;
        else if (Input.GetKeyDown("x"))
            rb.angularDrag = 0;

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 movement = new Vector3(0, 1, 0);
            rb.AddForce(300.0F * movement);
        }
		#if !UNITY_ANDROID
        else if(Input.GetMouseButtonDown(0) )
        {
            print("Jump !");
            Vector3 movement = new Vector3(0, 1, 0);
            rb.AddForce(300.0F * movement);
        }
		#endif
        else if (Input.GetButton("Fire2"))
        {
            print("Jump with Fire 2 button!");
            Vector3 movement = new Vector3(0, 1, 0);
            rb.AddForce(30.0F * movement);
        }


		#if UNITY_ANDROID
		Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

		float moveHorizontal 	= -0.01f * touchDeltaPosition.x;
		float moveVertical 		= -0.01f * touchDeltaPosition.y;

		#else

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		#endif

        Vector3 movement1 = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement1 * speed);

    }

    void FixedUpdate()
    {
        
        
           
    }

    
}

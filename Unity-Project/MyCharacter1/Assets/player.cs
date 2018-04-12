using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public Animator anim;
    public Rigidbody rb;

    private float x1;
    private float y1;
    private bool bRun;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        bRun = false;
    }
	
	// Update is called once per frame
	void Update () {
        //rb.velocity = new Vector3(100f, 0f, 0f);
        //Vector3 f1 = new Vector3(100f, 0f, 0f);
        //rb.AddRelativeForce(f1);
        x1 = Input.GetAxis("Horizontal");
        y1 = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            bRun = true;
        }
        else
        {
            bRun = false;
        }

        anim.SetFloat("inputHori", x1);
        anim.SetFloat("inputVert", y1);
        anim.SetBool("bRun", bRun);
        

        if (Input.GetKeyDown("1"))
        {
            anim.Play("WAIT01", -1, 0);
        }
        else if (Input.GetKeyDown("2"))
        {
            anim.Play("WAIT02", -1, 0);
        }
        else if (Input.GetKeyDown("3"))
        {
            anim.Play("WAIT03", -1, 0);
        }
        else if (Input.GetKeyDown("4"))
        {
            anim.Play("WAIT04", -1, 0);
        }
        else if (Input.GetKeyDown("4"))
        {
            anim.Play("WAIT04", -1, 0);
        }
        else if (Input.GetKeyDown("space"))
        {
            anim.Play("JUMP00", -1, 0);
        }

        

        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("DAMAGED00", -1, 0);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            anim.Play("DAMAGED01", -1, 0);
        }

        if (y1 > 0.1 || y1 < -0.1) // 세로방향 키보드가 입력이 되었을때에만
        {
            float moveX = x1 * 20f * Time.deltaTime;
            float moveZ = y1 * 50f * Time.deltaTime;
            //rb.velocity = new Vector3(moveX, 0f, moveZ);

            if(bRun)
            {
                moveX = moveX * 3.0f;
                moveZ = moveZ * 3.0f;
            }
            Vector3 f1 = new Vector3(moveX, 0f, moveZ);
            rb.AddForce(f1, ForceMode.VelocityChange);
        }
        print(y1);
        
        
        
    }
}

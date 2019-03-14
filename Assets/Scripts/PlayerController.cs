using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float mithShards;
    private float woodLogs;

    public Animator anim;
    public float speed;
    public bool hasSword;
    public bool hasBow;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        mithShards = 0;
        woodLogs = 0;
        hasBow = false;
        hasSword = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        float movement = -3;
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("movement should be 3");
            movement = 3;
            anim.SetBool("isWalking", true);
        }
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("isWalking", false);
        }

        anim.SetFloat("Speed", movement);


        Vector3 move = new Vector3(h, 0.0f, v);
        Vector3 rotate = new Vector3(0.0f, h, 0.0f);

        rb.AddForce(transform.forward * v * speed);
        rb.AddTorque(rotate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mithril"))
        {
            other.gameObject.SetActive(false);
            mithShards++;

        }
        else if (other.gameObject.CompareTag("Log"))
        {
            other.gameObject.SetActive(false);
            woodLogs++;
        }
    }

}

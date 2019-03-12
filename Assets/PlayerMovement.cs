using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody rb;
	public float speed;
	bool hasSword = true;
	public Flowchart flowchart;
	public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		gameObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		updateStatus();
		rb.AddForce(movement * speed);
	}

	void updateStatus()
	{
		if (hasSword == true)
		{
			flowchart.hasSword = true;
		}
	}
}

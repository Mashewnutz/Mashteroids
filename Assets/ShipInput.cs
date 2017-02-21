using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput : MonoBehaviour {

	public float thrust = 1.0f;
	public float rotation = 1.0f;

	private Rigidbody2D rb2d;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){			
			rb2d.AddForce(transform.up * thrust);
		}
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			rb2d.rotation += rotation;
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			rb2d.rotation -= rotation;
		}
	}
}

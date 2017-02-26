
using UnityEngine;

public class AlignWithVelocity : MonoBehaviour {

	private Rigidbody2D rb2d;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}	
		
	void Update () {
		transform.up = rb2d.velocity;
	}
}

using UnityEngine;

public class ShipInput : MonoBehaviour {
	public GameObject bulletPrefab;
	public float thrust = 1.0f;
	public float rotation = 1.0f;
	public float bulletSpeed = 1.0f;
	private Rigidbody2D rb2d;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Space)){
			var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
			var bulletRb2d = bullet.GetComponent<Rigidbody2D>();
			bulletRb2d.velocity = transform.up;
			bulletRb2d.velocity.Normalize();
			bulletRb2d.velocity *= bulletSpeed;
		}
	}
		
	void FixedUpdate () {
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

using UnityEngine;

public class AsteroidMotion : MonoBehaviour {

	public float minSpeed = 1;
	public float maxSpeed = 1;	
	public float rotationSpeed = 1;
	private Rigidbody2D rb2d;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	void OnEnable () {
		float randomSpeed = Random.Range(minSpeed, maxSpeed);
		var velocity = Vector3.zero-transform.position;
		velocity.Normalize();
		velocity *= randomSpeed;
		
		rb2d.velocity = velocity;
		rb2d.angularVelocity = rotationSpeed * RandomSign();
	}

	int RandomSign() {
		return Random.value < 0.5f ? -1 : 1;
	}
}

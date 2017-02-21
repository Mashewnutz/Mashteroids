using UnityEngine;

public class AsteroidMotion : MonoBehaviour {

	public float minSpeed = 1;
	public float maxSpeed = 1;
	private Rigidbody2D rb2d;
	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}
	void Start () {
		float randomSpeed = Random.Range(minSpeed, maxSpeed);
		float randomDirection = Random.Range(0, 2*Mathf.PI);
		
		var velocity = new Vector2(Mathf.Sin(randomDirection), Mathf.Cos(randomDirection));
		velocity *= randomSpeed;

		rb2d.velocity = velocity;
	}
}

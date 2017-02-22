using UnityEngine;

public class AsteroidCollision : MonoBehaviour {	
	public GameObject prefabToSpawn;
	public int explosionForce = 5;
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Bullet"){
			GameEvents.instance.OnAsteroidDestroyed(gameObject);
			Explode(collision);
			Destroy(gameObject);
			Destroy(collision.gameObject);			
		} else if(collision.gameObject.tag == "Player"){
			GameEvents.instance.OnPlayerDeath();
			Destroy(collision.gameObject);			
		}
	}

	void Explode(Collision2D collision){	
		if(prefabToSpawn == null)	
			return;

		var asteroid1 = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
		var asteroid2 = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

		float xVel = -collision.contacts[0].normal.y;
		float yVel = collision.contacts[0].normal.x;
		Vector2 velocity = new Vector2(xVel, yVel);
		velocity.Normalize();
		velocity *= explosionForce;

		asteroid1.GetComponent<Rigidbody2D>().velocity = velocity;
		asteroid2.GetComponent<Rigidbody2D>().velocity = -velocity;
	}
}

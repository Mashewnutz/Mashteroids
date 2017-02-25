using UnityEngine;

public class AsteroidCollision : MonoBehaviour {	
	
	public PoolId childAsteroid;
	public int explosionForce = 5;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Bullet"){
			GameEvents.instance.OnAsteroidDestroyed(gameObject);	
			Explode(collision);			
			PoolManager.Instance.Deallocate(gameObject);
			PoolManager.Instance.Deallocate(collision.gameObject);
		} else if(collision.gameObject.tag == "Player"){
			GameEvents.instance.OnPlayerDeath();
			Destroy(collision.gameObject);				
		}
	}

	void Explode(Collision2D collision){	
		if(childAsteroid == PoolId.Invalid)	
			return;

		var asteroid1 = PoolManager.Instance.Allocate(childAsteroid, transform.position);
		var asteroid2 = PoolManager.Instance.Allocate(childAsteroid, transform.position);

		float xVel = -collision.contacts[0].normal.y;
		float yVel = collision.contacts[0].normal.x;
		Vector2 velocity = new Vector2(xVel, yVel);
		velocity.Normalize();
		velocity *= explosionForce;

		asteroid1.GetComponent<Rigidbody2D>().velocity = velocity;
		asteroid2.GetComponent<Rigidbody2D>().velocity = -velocity;
	}
}

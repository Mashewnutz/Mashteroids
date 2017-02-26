using UnityEngine;

public class AsteroidCollision : MonoBehaviour {	

	public GameObject explosion;
	public PoolId childAsteroid;
	public int explosionForce = 5;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Bullet"){
			Explode(collision);
			PoolManager.Instance.Deallocate(gameObject);
			GameEvents.Instance.OnAsteroidDestroyed.Invoke(gameObject);							
		}
	}

	void Explode(Collision2D collision){	
		if(explosion != null)
			GameObject.Instantiate(explosion, transform.position, transform.rotation);
			
		if(childAsteroid == PoolId.Invalid)	
			return;

		var asteroid1 = PoolManager.Instance.Allocate(childAsteroid, transform.position, Quaternion.identity);
		var asteroid2 = PoolManager.Instance.Allocate(childAsteroid, transform.position, Quaternion.identity);

		float xVel = -collision.contacts[0].normal.y;
		float yVel = collision.contacts[0].normal.x;
		Vector2 velocity = new Vector2(xVel, yVel);
		velocity.Normalize();
		velocity *= explosionForce;

		asteroid1.GetComponent<Rigidbody2D>().velocity = velocity;
		asteroid2.GetComponent<Rigidbody2D>().velocity = -velocity;		
	}
}

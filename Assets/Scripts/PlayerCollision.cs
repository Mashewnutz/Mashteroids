using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "EnemyBullet"){
			Destroy(gameObject);		
			GameEvents.instance.OnPlayerDeath();
		} else if(other.gameObject.tag == "Asteroid"){
			Destroy(gameObject);
			GameEvents.instance.OnPlayerDeath();			
		}
	}
}
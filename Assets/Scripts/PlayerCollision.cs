using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "EnemyBullet"){
			GameEvents.instance.OnPlayerDeath();
			Destroy(gameObject);						
		} else if(other.gameObject.tag == "Asteroid"){
			GameEvents.instance.OnPlayerDeath();
			Destroy(gameObject);
		}
	}
}
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "EnemyBullet"){
			GameEvents.instance.OnPlayerDeath();
			Destroy(gameObject);
			Destroy(other.gameObject);			
		}
	}
}
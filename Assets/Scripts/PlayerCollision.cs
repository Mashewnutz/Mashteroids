using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "EnemyBullet"){
			PoolManager.Instance.Deallocate(gameObject);		
			GameEvents.instance.OnPlayerDeath();
		} else if(other.gameObject.tag == "Asteroid"){
			PoolManager.Instance.Deallocate(gameObject);
			GameEvents.instance.OnPlayerDeath();			
		}
	}
}
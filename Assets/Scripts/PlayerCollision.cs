using UnityEngine;

public class PlayerCollision : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "EnemyBullet"){
			PoolManager.Instance.Deallocate(gameObject);		
			GameEvents.Instance.OnPlayerDestroyed.Invoke();
		} else if(other.gameObject.tag == "Asteroid"){
			PoolManager.Instance.Deallocate(gameObject);
			GameEvents.Instance.OnPlayerDestroyed.Invoke();			
		} else if(other.gameObject.tag == "Ufo"){
			PoolManager.Instance.Deallocate(gameObject);
			GameEvents.Instance.OnPlayerDestroyed.Invoke();
		}
	}
}
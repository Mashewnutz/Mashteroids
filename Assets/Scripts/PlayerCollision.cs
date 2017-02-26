using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public bool invincible = false;

	void OnCollisionEnter2D(Collision2D other)
	{
		if(invincible){
			return;
		}

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
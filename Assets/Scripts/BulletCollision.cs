using UnityEngine;

public class BulletCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player"){
			PoolManager.Instance.Deallocate(gameObject);
		} else if(other.gameObject.tag == "Asteroid"){
			PoolManager.Instance.Deallocate(gameObject);
		} else if(other.gameObject.tag == "Ufo"){
			PoolManager.Instance.Deallocate(gameObject);
		}
	}
}

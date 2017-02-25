using UnityEngine;

public class UfoCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Bullet"){			
			PoolManager.Instance.Deallocate(gameObject);
			GameEvents.Instance.OnUfoDestroyed.Invoke(gameObject);
		}
	}
}

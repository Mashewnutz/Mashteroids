using UnityEngine;

public class UfoCollision : MonoBehaviour {
			
	public GameObject explosion;

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Bullet"){			
			if(explosion != null)
				GameObject.Instantiate(explosion, transform.position, transform.rotation);

			PoolManager.Instance.Deallocate(gameObject);
			GameEvents.Instance.OnUfoDestroyed.Invoke(gameObject);
		}
	}
}

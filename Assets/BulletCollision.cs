using UnityEngine;

public class BulletCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Bullet"){
			Destroy(gameObject);
		}		
	}
}

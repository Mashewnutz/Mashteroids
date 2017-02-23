using UnityEngine;

public class UfoCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Bullet"){
			GameEvents.instance.OnUfoDestroyed(gameObject);
			Destroy(gameObject);
			Destroy(other.gameObject);			
		}
	}
}

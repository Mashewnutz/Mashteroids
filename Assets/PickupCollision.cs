using UnityEngine;

public class PickupCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
			var pickup = GetComponentInChildren<Pickup>(true);		
			pickup.AttachToPlayer(other.gameObject);
			pickup.gameObject.SetActive(true);
			Destroy(gameObject);
		}
	}
}

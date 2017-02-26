using UnityEngine;

public class PickupCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){			
			var existingPickup = other.gameObject.GetComponentInChildren<Pickup>();
			if(existingPickup != null){
				Destroy(existingPickup.gameObject);
			}

			var pickup = GetComponentInChildren<Pickup>(true);
			pickup.AttachToPlayer(other.gameObject);
			pickup.gameObject.SetActive(true);
			Destroy(gameObject);
			GameEvents.Instance.OnPickupCollected.Invoke(pickup.gameObject);
		}
	}
}

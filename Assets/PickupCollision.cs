using UnityEngine;

public class PickupCollision : MonoBehaviour {

	private GameObject powerUp;

	void Awake(){
		powerUp = transform.GetChild(0).gameObject;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
			powerUp.transform.SetParent(other.gameObject.transform, false);
			powerUp.SetActive(true);
			Destroy(gameObject);
		}
	}
}

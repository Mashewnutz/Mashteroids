using UnityEngine;

public class AsteroidCollision : MonoBehaviour {
	private GameEvents gameEvents;
	void Awake() {
		gameEvents = FindObjectOfType<GameEvents>();
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Bullet"){
			Destroy(gameObject);
			Destroy(other.gameObject);
			gameEvents.AsteroidDestroyed.Invoke();
		} else if(other.gameObject.tag == "Player"){
			Destroy(other.gameObject);
			gameEvents.PlayerDeath.Invoke();
		}
	}
}

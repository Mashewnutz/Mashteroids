using UnityEngine;

public class Lives : MonoBehaviour {

	private Life[] lifes;
	private int lives = 3;
	
	void Start() {
		GameEvents.Instance.OnPlayerDestroyed.AddListener(OnPlayerDeath);
		lifes = transform.GetComponentsInChildren<Life>();		
	}

	public void OnPlayerDeath() {
		lives--;	
		for(int i = 0; i < lifes.Length; ++i){			
			lifes[i].SetFilled(i < lives);
		}		
	}
}

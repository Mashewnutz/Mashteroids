using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {

	private Life[] lifes;
	private int lives = 3;
	void Awake() {
		lifes = transform.GetComponentsInChildren<Life>();
	}

	public void OnPlayerDeath() {
		lives--;	
		for(int i = 0; i < lifes.Length; ++i){			
			lifes[i].SetFilled(i < lives);
		}		
	}
}

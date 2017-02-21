using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour {

	public float timeToLiveSeconds = 1.0f;	
	
	// Update is called once per frame
	void Update () {
		timeToLiveSeconds -= Time.deltaTime;
		if(timeToLiveSeconds < 0){
			Destroy(gameObject);
		}
	}
}

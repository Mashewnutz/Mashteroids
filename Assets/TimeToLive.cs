
using UnityEngine;

public class TimeToLive : MonoBehaviour {

	public float timeToLive = 1;
	
	void Start () {
		Destroy(gameObject, timeToLive);
	}	
}

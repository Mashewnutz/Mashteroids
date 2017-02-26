using UnityEngine;

public class Thruster : MonoBehaviour {

	private int index;
	
	void OnEnable () {
		index = 0;
		foreach(Transform child in transform){
			child.gameObject.SetActive(false);
		}
	}
	
	
	void Update () {		
		transform.GetChild(index).gameObject.SetActive(false);
		index = (index + 1) % transform.childCount;
		transform.GetChild(index).gameObject.SetActive(true);
	}
}

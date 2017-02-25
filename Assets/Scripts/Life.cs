using UnityEngine;

public class Life : MonoBehaviour {
	private GameObject lifeFilled;	
	void Awake () {
		lifeFilled = transform.GetChild(0).gameObject;
	}	
	public void SetFilled (bool filled) {
		lifeFilled.SetActive(filled);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	private GameObject lifeFilled;
	
	// Use this for initialization
	void Awake () {
		lifeFilled = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	public void SetFilled (bool filled) {
		lifeFilled.SetActive(filled);
	}
}

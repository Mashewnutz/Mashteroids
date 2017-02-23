using UnityEngine;

public class DestroyWhenGoingOffScreen : MonoBehaviour {

	private Renderer componentRenderer;
	private bool isVisible = false;
	void Awake(){
		componentRenderer = GetComponent<Renderer>();
	}
	// Update is called once per frame
	void Update () {		
		if(componentRenderer.isVisible){
			isVisible = true;
		}
			
		if(isVisible && !componentRenderer.isVisible){
			Destroy(gameObject);
		}
	}
}

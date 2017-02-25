using UnityEngine;

public class ReturnToPoolWhenGoingOffScreen : MonoBehaviour {	

	private Renderer componentRenderer;
	private bool isVisible;

	void Awake(){
		componentRenderer = GetComponent<Renderer>();
	}

	void OnEnable() {
		isVisible = false;
	}
	
	void Update () {		
		if(componentRenderer.isVisible){
			isVisible = true;
		}
			
		if(isVisible && !componentRenderer.isVisible){
			ReturnToPool();
		}
	}

	void ReturnToPool() {
   		PoolManager.Instance.Deallocate(gameObject);		
	}
}

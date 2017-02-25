using UnityEngine;

public class ReturnToPoolWhenGoingOffScreen : MonoBehaviour {	

	private Renderer componentRenderer;
	private bool isVisible = false;

	void Awake(){
		componentRenderer = GetComponent<Renderer>();
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

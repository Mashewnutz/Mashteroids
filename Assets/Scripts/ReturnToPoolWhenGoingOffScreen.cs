using UnityEngine;

public class ReturnToPoolWhenGoingOffScreen : MonoBehaviour {	
	
	private bool objectHasComeOnScreen;

	void OnEnable() {
		objectHasComeOnScreen = false;
	}
	
	void Update () {
		var visibleThisFrame = IsVisible();
		if(visibleThisFrame){
			objectHasComeOnScreen = true;
		}
			
		if(objectHasComeOnScreen && !visibleThisFrame){
			ReturnToPool();
		}
	}

	bool IsVisible() {
		var screenPos = Camera.main.WorldToScreenPoint(transform.position);
		if(screenPos.x < 0)
			return false;
		if(screenPos.x > Screen.width)
			return false;
		if(screenPos.y < 0)
			return false;
		if(screenPos.y > Screen.height)
			return false;
		return true;
	}

	void ReturnToPool() {
   		PoolManager.Instance.Deallocate(gameObject);		
	}
}

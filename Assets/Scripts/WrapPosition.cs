using UnityEngine;

public class WrapPosition : MonoBehaviour {
				
	void LateUpdate () {
		var screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if(screenPosition.x < 0){
			screenPosition.x += Screen.width;
			SetScreenPosition(screenPosition);			
		} else if(screenPosition.x > Screen.width){
			screenPosition.x -= Screen.width;
			SetScreenPosition(screenPosition);
		} 
		
		if(screenPosition.y < 0){			
			screenPosition.y += Screen.height;
			SetScreenPosition(screenPosition);
		} else if(screenPosition.y > Screen.height){
			screenPosition.y -= Screen.height;
			SetScreenPosition(screenPosition);
		}
	}

	void SetScreenPosition(Vector3 screenPosition){
		var worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
		transform.position = worldPosition;
	}
}

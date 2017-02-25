using UnityEngine;

public class UfoMovement : MonoBehaviour {
	
	public float speed = 1;
	private int direction;

	void OnEnable() {
		if(transform.position.x < 0){
			direction = 1;
		} else {
			direction = -1;
		}
	}

	void Update()
	{
		transform.Translate(speed * direction * Time.deltaTime, 0, 0);
	}
}

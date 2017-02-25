using UnityEngine;

public class Teleport : MonoBehaviour {
		
	public KeyCode teleportKey = KeyCode.E;
	
	void Update () {
		if(Input.GetKeyDown(teleportKey)){
			float x = Random.Range(0, Screen.width);
			float y = Random.Range(0, Screen.height);
			var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
			transform.Translate(worldPos.x, worldPos.y, 0);
		}
	}
}

using UnityEngine;

public class Background : MonoBehaviour {

	static Background instance = null;

	void Start () {
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}		
	}	
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKeyToContinue : MonoBehaviour {

	public string sceneToLoad;

	void Update() {
		if(Input.anyKeyDown){
			SceneManager.LoadScene(sceneToLoad);
		}
	}
}

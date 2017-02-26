using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour {

	public float rate;	
	private Text text;

	void Awake() {
		text = GetComponent<Text>();			
	}

	void OnEnable () {
		Invoke("HideShowText", rate);
	}
	
	void HideShowText(){
		text.enabled = !text.enabled;		
		Invoke("HideShowText", rate);
	}
}

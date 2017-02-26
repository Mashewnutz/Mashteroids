using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour {

	public float rate;	
	private Text text;

	void Awake() {
		text = GetComponent<Text>();			
	}

	void Start () {
		Invoke("HideShowSprite", rate);
	}
	
	void HideShowSprite(){
		text.enabled = !text.enabled;		
		Invoke("HideShowSprite", rate);
	}
}

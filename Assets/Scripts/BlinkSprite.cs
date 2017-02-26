using UnityEngine;

public class BlinkSprite : MonoBehaviour {

	public float rate;	
	private SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();			
	}

	void OnEnable () {
		Invoke("HideShowSprite", rate);
		spriteRenderer.enabled = true;
	}

	void OnDisable() {
		spriteRenderer.enabled = true;
		CancelInvoke();
	}
	
	void HideShowSprite(){
		spriteRenderer.enabled = !spriteRenderer.enabled;		
		Invoke("HideShowSprite", rate);
	}
}

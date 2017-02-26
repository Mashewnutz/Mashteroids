using UnityEngine;

public class SoundEffects : MonoBehaviour {
	
	public static SoundEffects Instance;
	private AudioSource output;	

	void Awake() {		
		output = GetComponent<AudioSource>();
		Instance = this;	
	}

	public void Play (AudioClip clip) {		
		output.PlayOneShot(clip);
	}
}

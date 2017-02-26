using UnityEngine;
using UnityEngine.Events;

public class GameObjectEvent : UnityEvent<GameObject> {}
public class IntEvent : UnityEvent<int> {}

public class GameEvents : MonoBehaviour {
		
	public static GameEvents Instance;
	public UnityEvent OnGameOver = new UnityEvent();	
	public UnityEvent OnPlayerDestroyed = new UnityEvent();	
	public IntEvent OnWaveCleared = new IntEvent();
	public IntEvent OnNewWave = new IntEvent();
	public GameObjectEvent OnAsteroidDestroyed = new GameObjectEvent();
	public GameObjectEvent OnUfoDestroyed = new GameObjectEvent();
	public GameObjectEvent OnPickupCollected = new GameObjectEvent();

	void Awake(){
		Instance = this;			
	}	
}

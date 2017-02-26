using System.Collections.Generic;
using UnityEngine;

public enum PoolId{
	Invalid,
	Bullet,
	EnemyBullet,
	LargeAsteroid,
	MediumAsteroid,
	SmallAsteroid,
	LargeUfo,
	SmallUfo,
	Player,
	Missile
}

[System.Serializable]
public class ObjectPoolId{
	public PoolId poolId;
	public GameObject prefab;
	public int preallocate;
	public int growSize;
}

public class PoolManager : MonoBehaviour {

	public static PoolManager Instance;
			
	public ObjectPoolId[] objectPools;
	private Dictionary<PoolId, ObjectPool> objectPoolInstances;

	void Awake () {
		Instance = this;
		objectPoolInstances = new Dictionary<PoolId, ObjectPool>();
		foreach(var objectPool in objectPools){
			objectPoolInstances.Add(objectPool.poolId, new ObjectPool(objectPool.prefab, transform, objectPool.preallocate, objectPool.growSize));
		}	
	}

	public GameObject Allocate(PoolId poolId, Vector3 position, Quaternion rotation){
		ObjectPool pool;
		if(objectPoolInstances.TryGetValue(poolId, out pool)){
			var go = pool.Allocate(position, rotation);
			var poolTypeComponent = go.GetComponent<PoolAllocation>();
            if(!poolTypeComponent){
                poolTypeComponent = go.AddComponent<PoolAllocation>();
                poolTypeComponent.poolId = poolId;
            }
			return go;
		} else {
			Debug.LogError("Pool " + poolId.ToString() + " has not been configured or initialised");
			return null;
		}		
	}

	public void Deallocate(GameObject gameObject){
		var allocation = gameObject.GetComponent<PoolAllocation>();
		if(allocation){
			ObjectPool pool;
			if(objectPoolInstances.TryGetValue(allocation.poolId, out pool)){
				pool.Deallocate(gameObject);
			}		
		} else {
			Debug.LogError("Object " + gameObject.name + " was not allocated from a pool");
			Destroy(gameObject);
		}
	}

	public int GetAllocatedCount(PoolId poolId){
		ObjectPool pool;
		if(objectPoolInstances.TryGetValue(poolId, out pool)){
			return pool.GetAllocatedCount();
		} else {
			Debug.LogError("Pool " + poolId.ToString() + " has not been configured or initialised");
			return 0;
		}		
	}
}

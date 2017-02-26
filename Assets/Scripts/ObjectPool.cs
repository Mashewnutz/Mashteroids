using UnityEngine;
using System.Collections.Generic;

public class ObjectPool {
    
    private Transform parent;
    private List<GameObject> objectPool;
    private int allocated = 0;    
    private int growSize = 0;
    private GameObject prefab;

    public ObjectPool(GameObject prefab, Transform parent, int preallocate, int growSize){        
        this.parent = parent;
        this.growSize = growSize;
        this.objectPool = new List<GameObject>();
        this.prefab = prefab;
        this.prefab.SetActive(false);
        Expand(preallocate);        
    }

    public GameObject Allocate(Vector3 position, Quaternion rotation){
        if(objectPool.Count == 0){
            Expand(growSize);
        }  

        var go = objectPool[objectPool.Count-1];
        objectPool.RemoveAt(objectPool.Count-1);
        go.transform.position = position;
        go.transform.rotation = rotation;
        go.SetActive(true);      
        allocated++; 
        return go;
    }

    public void Deallocate(GameObject gameObject){
        objectPool.Add(gameObject);
        gameObject.SetActive(false);
        gameObject.transform.SetParent(parent);
        allocated--;
    }

    public int GetAllocatedCount(){
        return allocated;
    }

    void Expand(int count){ 
        for(int i = 0; i < count; ++i){
            var go = GameObject.Instantiate(prefab);
            go.transform.SetParent(parent);
            go.SetActive(false);            
            objectPool.Add(go);
        }
    }    
}
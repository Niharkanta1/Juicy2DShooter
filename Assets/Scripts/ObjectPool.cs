using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       19-01-2023 20:18:10
================================================*/ 
public class ObjectPool : MonoBehaviour {

    [SerializeField]
    protected GameObject objectToSpawn;
    [SerializeField]
    protected int poolSize;
    protected int currentSize;
    protected Queue<GameObject> objectPool;
    protected GameObject parentObject;

    private void Awake() {
        objectPool = new Queue<GameObject>();
        parentObject = new GameObject(objectToSpawn.name + "_ObjectPool");
    }

    public virtual GameObject SpawnObject(GameObject currentObject = null) {
        if (currentObject == null) {
            currentObject = objectToSpawn;
        }
        GameObject spawnObject = null;

        if (currentSize < poolSize) {
            spawnObject = Instantiate(currentObject, transform.position, Quaternion.identity);
            spawnObject.name = currentObject.name + "_" + currentSize;
            currentSize++;
        } else {
            spawnObject = objectPool.Dequeue();
            spawnObject.transform.position = transform.position;
            spawnObject.transform.rotation = Quaternion.identity;
        }
        spawnObject.transform.SetParent(parentObject.transform);
        objectPool.Enqueue(spawnObject);
        return spawnObject;
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       22-01-2023 20:21:16
================================================*/ 
public class ItemDropper : MonoBehaviour {

    [SerializeField]
    private List<ItemSpawnData> itemsToDrop;
    
    private float[] itemWeights;
    
    [SerializeField]
    [Range(0,1)]
    private float dropChance = 0.2f;

    private void Start() {
        itemWeights = itemsToDrop.Select(item => item.rate).ToArray();
    }

    public void DropItem() {
        var dropVariable = Random.value;
        if(dropVariable < dropChance) {
            int index = GetRandomWeightedIndex(itemWeights);
            Instantiate(itemsToDrop[index].itemPrefab, transform.position, Quaternion.identity);
        }
    }

    private int GetRandomWeightedIndex(float[] itemWeights) {
        float sum = itemWeights.Aggregate((a, b) => a + b);
        float randomValue = Random.Range(0, sum);
        float tempSum = 0;
        for(int i=0; i<itemsToDrop.Count; i++) {
            if(randomValue >= tempSum && randomValue < tempSum + itemWeights[i]) {
                return i;
            }
            tempSum += itemWeights[i];
        }
        return 0;
    }
}

[System.Serializable]
public struct ItemSpawnData {
    [Range(0, 1)]
    public float rate;
    public GameObject itemPrefab;
}
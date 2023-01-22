using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       22-01-2023 19:53:35
================================================*/
[CreateAssetMenu(menuName = "Item/ResourceData")] 

public class ResourceDataSO : ScriptableObject {

    [field: SerializeField]
    public ResourceType resourceType { get; set; }
    [SerializeField]
    private int minAmount = 1, maxAmount = 5;

    public int getAmount() {
        return Random.Range(minAmount, maxAmount+1);
    }
}

public enum ResourceType {
    None,
    Health,
    Ammo
}
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint {
    public GameObject upgradedPrefab;
    public GameObject prefab;
    public Text buyCostText;
    public int upgradeCost;

    [HideInInspector]
    public int cost = 50;
    [HideInInspector]
    public int sellCost;

    public bool maxUpgraded { get { return upgradedPrefab == null; } }
}
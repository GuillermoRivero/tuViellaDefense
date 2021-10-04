using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager running!");
            return;
        } 
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject elizabethWarrenPrefab;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HaveMoneyToBuild { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (Node node) {
        if (!HaveMoneyToBuild){
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.currentTurret = turret;
        GameObject effect = (GameObject) Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect,5f);
        turretToBuild = null;

        Debug.Log("Turret Build! Money left: " + PlayerStats.Money);
    }


    public void SelectTurretToBuild (TurretBlueprint turret) {
        turretToBuild = turret;
    }
    
   
}

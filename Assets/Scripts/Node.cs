using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update
    public Color canBuildHoverColor;
    public Color cantBuildHoverColor;

    [HideInInspector]
    public GameObject currentTurret;
    [HideInInspector]
    public TurretBlueprint currentTurretBlueprint;

    public Vector3 positionOffset;    

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown() {

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (currentTurret != null) {
            rend.material.color = startColor;
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild){
            buildManager.DeselectNode();
            return;
        }

        //Build a turret
        BuildTurret(buildManager.GetTurretToBuild());
    }

    public void BuildTurret(TurretBlueprint blueprint) {

        if (!HaveMoneyToBuild(blueprint)){
            Debug.Log("Not enough money to build that!");
            rend.material.color = cantBuildHoverColor;
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject turret = (GameObject) Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        currentTurret = turret;
        currentTurretBlueprint = blueprint;

        GameObject effect = (GameObject) Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect,5f);

        //buildManager.turretToBuild = null;
        rend.material.color = startColor;
        buildManager.nodeUI.Hide();
        buildManager.SelectTurretToBuild(null);

        Debug.Log("Turret Build!");
    }

    public void UpgradeTurret() {
        if (!HaveMoneyToUpgrade(currentTurretBlueprint)){
            Debug.Log("Not enough money to build that!");
            rend.material.color = cantBuildHoverColor;
            return;
        }

        if (!currentTurretBlueprint.maxUpgraded){
            PlayerStats.Money -= currentTurretBlueprint.upgradeCost;

            //Get rid of the old turret
            Destroy(currentTurret);

            //Building a new one
            GameObject turret = (GameObject) Instantiate(currentTurretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
            currentTurret = turret;

            GameObject effect = (GameObject) Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); // TODO upgrade effect
            Destroy(effect,5f);

            //buildManager.turretToBuild = null;
            rend.material.color = startColor;
            buildManager.nodeUI.Hide();
            buildManager.SelectTurretToBuild(null);

            Debug.Log("Turret Upgraded!");
        } else {
            Debug.Log("This turret is max upgraded!");
        }
    }

    public void SellTurret() {

        PlayerStats.Money += currentTurretBlueprint.sellCost;

        //Get rid of the old turret
        Destroy(currentTurret);

        //Building a new one
        currentTurret = null;

        GameObject effect = (GameObject) Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); // TODO sell effect
        Destroy(effect,5f);

        //buildManager.turretToBuild = null;
        rend.material.color = startColor;
        buildManager.nodeUI.Hide();
        buildManager.SelectTurretToBuild(null);

        Debug.Log("Turret Selled!");
    }

    void OnMouseEnter () { 

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild){
            return;
        }

        if (HaveMoneyToBuild(buildManager.GetTurretToBuild()) && this.currentTurret == null) {
            rend.material.color = canBuildHoverColor;
        } else {
            rend.material.color = cantBuildHoverColor;
        }
    }

    void OnMouseExit () { 
        rend.material.color = startColor;
    }

    // Update is called once per frame
    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }

    private bool HaveMoneyToBuild(TurretBlueprint blueprint) { 
        return PlayerStats.Money >= blueprint.cost; 
    } 

    private bool HaveMoneyToUpgrade(TurretBlueprint blueprint) { 
        return PlayerStats.Money >= blueprint.upgradeCost; 
    } 
}

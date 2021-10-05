using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint elizabethWarrenTurret;

    BuildManager buildManager;
    void Start() {
        buildManager = BuildManager.instance;
        prepareTurretBlueprints();
    }

    public void SelectStandardTurret () {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher () {
        Debug.Log("Missile Launcher Purchased");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectElizabethWarrenTurret () {
        Debug.Log("ElizabethWarren Turret Purchased");
        buildManager.SelectTurretToBuild(elizabethWarrenTurret);
    }

    void prepareTurretBlueprints() {
        initializeTurret(standardTurret);
        initializeTurret(missileLauncher);
        initializeTurret(elizabethWarrenTurret);
    }

    void initializeTurret(TurretBlueprint turretBlueprint) {
        turretBlueprint.cost = turretBlueprint.prefab.GetComponent<Turret>().totalCost;
        turretBlueprint.sellCost = turretBlueprint.cost/2;
        turretBlueprint.buyCostText.text = turretBlueprint.cost.ToString();
    }
}

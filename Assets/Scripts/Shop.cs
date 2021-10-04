using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint elizabethWarrenTurret;

    BuildManager buildManager;
    void Start() {
        buildManager = BuildManager.instance;
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
}

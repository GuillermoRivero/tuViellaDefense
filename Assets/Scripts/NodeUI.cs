using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private float positionOffsetZ = 1f;
    public Text upgradeCost;
    private Node target;
    
    public void SetTarget (Node _target) {
        this.target = _target;
        Turret currentTurret = _target.currentTurret.GetComponent<Turret>();
        Debug.Log("CurrentTurret" + currentTurret);
        Debug.Log("CurrentTurretHeight" + currentTurret.height);

        transform.position = target.GetBuildPosition() + Vector3.up * currentTurret.height + Vector3.forward * positionOffsetZ;

        upgradeCost.text = this.target.currentTurretBlueprint.upgradeCost.ToString();
        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

    public void Upgrade () {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell () {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}

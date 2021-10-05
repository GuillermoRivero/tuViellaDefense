using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update
    public Color canBuildHoverColor;
    public Color cantBuildHoverColor;

    [Header("Optional")]
    public GameObject currentTurret;
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
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild){
            buildManager.DeselectNode();
            return;
        }
            

        //Build a turret
        buildManager.BuildTurretOn(this);
        rend.material.color = startColor;
    }

    void OnMouseEnter () { 

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild){
            return;
        }

        if (buildManager.HaveMoneyToBuild) {
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
}

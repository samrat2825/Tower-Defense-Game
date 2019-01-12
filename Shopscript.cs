
using UnityEngine;

public class Shopscript : MonoBehaviour {

    Buildmanager buildManager;

    void Start()
    {   
        buildManager = Buildmanager.instance;
    }


   public void PurchasedStandardTurret()
    {
        Debug.Log("DD");
        buildManager.SetTurretBuild(buildManager.standardTurretPrefab);
    }

    public void PurchasedSecondaryTurret()
    {
        Debug.Log("DD");
        buildManager.SetTurretBuild(buildManager.secondaryTurretPrefab);
    }
}

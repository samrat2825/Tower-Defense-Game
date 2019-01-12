using UnityEngine;

public class Buildmanager : MonoBehaviour {

    public static Buildmanager instance;

    void Awake()
    {
        if(instance != null)
        {

            Debug.Log("MOre than one buildmanager");
            return;

        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject secondaryTurretPrefab;



    /*void Start()
    {
        turrettobuild = standardTurretPrefab;
    }*/

    private GameObject turrettobuild;

    public GameObject Getturrettobuild()
    {
        
        return turrettobuild;
    }

     public void SetTurretBuild(  GameObject turret2build )
    {

        Debug.Log("SetTurret");
        turrettobuild = turret2build;
        
        
    }

}

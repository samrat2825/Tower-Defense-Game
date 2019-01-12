using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    //BUILDING A TURRET
    private GameObject turret;
    public Vector3 positionoffset;
    Buildmanager buildManager;

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //DON'T WANT TO BUILT ANYTHING THAT IS NULL 
        if (buildManager.Getturrettobuild() == null)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("You Cannot Build Here");
            return;
        }

        GameObject turrettobuild = buildManager.Getturrettobuild();
        turret = (GameObject)Instantiate(turrettobuild, transform.position + positionoffset, transform.rotation);

    }

    //Visual Color
    public Color hovercolor;
    private Renderer rend;
    private Color Startcolor;


    void Start()
    {
        rend = GetComponent<Renderer>();
        Startcolor = rend.material.color;

        //CREATING AN INSTANCE OF BUILDMANAGER
        buildManager = Buildmanager.instance;
    }

	void OnMouseEnter()
    {
         
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Hover Only when we have a turret to build
        if (buildManager.Getturrettobuild() == null)
        {
            return;
        }
        rend.material.color = hovercolor;
    }

    void OnMouseExit()
    {
        rend.material.color = Startcolor;
    }


}

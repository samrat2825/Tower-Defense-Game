using UnityEngine.UI;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public float scrollspeed = 5f;
    public float miny = 10f;
    public float maxy = 80f;
    
    //Scrool VIEW
    private bool Domovement = true;
    public float panspeed = 30f;
    public float panborderthickness;


   

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
            Domovement = !Domovement;


        if (!Domovement)
            return;

        if(Input.GetKey("w") || Input.mousePosition.y>= Screen.height - panborderthickness)
        {
            
            //For Moving In a Direction with Given Speed
            transform.Translate(Vector3.forward*panspeed*Time.deltaTime,Space.World);

        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panborderthickness)
        {
            
            
            transform.Translate(Vector3.back*panspeed*Time.deltaTime,Space.World);

        }if(Input.GetKey("d") || Input.mousePosition.x>= Screen.width - panborderthickness)
        {
            
          
            transform.Translate(Vector3.right*panspeed*Time.deltaTime,Space.World);

        }if(Input.GetKey("a") || Input.mousePosition.x<= panborderthickness)
        {
            
            
            transform.Translate(Vector3.left*panspeed*Time.deltaTime,Space.World);

        }

        //SCROOL VIEW

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll *1000* scrollspeed*Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, miny, maxy);

        transform.position = pos;
    }
}

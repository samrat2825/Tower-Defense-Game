
using UnityEngine;

public class WayPoints : MonoBehaviour {

    // STATIC IS USED TO FIX 
    public static Transform[] points;

    //ASSIGN THE WAVEPOINT NUMBER TO THE WAYPOINTS
     void Awake()
    {
        
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

}


using UnityEngine;

public class EnemyMov : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {

        {
            target = WayPoints.points[0];
        }
    }

    private void Update()
    {
        //TRANSLATIONAL MOVEMENT OF THE ENEMY
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position,target.position)<=0.2f)
        {
            Getnxtwaypoint();
        }
    }

    void Getnxtwaypoint()
    {
        //WHEN THE ENEMY REACHES THE END POINT IT GETS DESTROYED
        if(waypointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = WayPoints.points[waypointIndex];
    }

}




using UnityEngine;


public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 20f;

    public GameObject impact;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisframe = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisframe)
        {
            Hittarget();

            return;
            
        }

        transform.Translate(dir.normalized * distanceThisframe,Space.World);

    }

    void Hittarget()
    {   
        GameObject EffectIns = (GameObject)Instantiate(impact, transform.position, transform.rotation);
        Destroy(EffectIns, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);

    }
}

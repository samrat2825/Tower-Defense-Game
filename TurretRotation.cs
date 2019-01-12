using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretRotation : MonoBehaviour {


    private Transform target;

   [ Header("Attributes")]
    public float range = 10f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform parttoroatte;
    public float turnspeed = 10f;

    public GameObject Bulletprefab;
    public Transform firepoint;

    void Start()
    {   
        //Calling the function after a interval
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    void UpdateTarget()
    {   

        //Finding Enemy

        //MAKING AN ARRAY OF ENEMIES AND STORING EACH GAMOBJECT IN IT WITH THE TAG ENEMY
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;

        //WHEN THE FIRST ENEMY WILL BE FIND IT WILL BE ASSIGNED TO THIS GAMEOBJECT
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distancetoEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distancetoEnemy < shortestDistance)
            {
                shortestDistance = distancetoEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            // target IS TRANSFORM TYPE VARIABLE
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }


    }

    void Update()
    {

        if (target == null)
        {
            return;
        }

        //TargetLockOn
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);


        //FOR SMOOTH ROTATION
                //ROTATED IN EULER ANGLES
        Vector3 rotation = Quaternion.Lerp(parttoroatte.rotation, lookRotation,Time.deltaTime*turnspeed).eulerAngles;
        parttoroatte.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //Shoooting
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(Bulletprefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if(bullet!= null)
        {
            bullet.Seek(target);
        }
    }
    
    
    //ToShowRange
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}

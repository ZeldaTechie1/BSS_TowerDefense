using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class TurretNode : NodeTemplate {

    public bool canShoot;
    public float fireRate;
    public GameObject projectile;
    private List<GameObject> enemyList = new List<GameObject>();
    public Transform spawnPoint;

    void Start()//This just sets all the values for all the variables both in this class and the NodeTemplate class
    {
        meshr = GetComponent<MeshFilter>();
        rendr = GetComponent<MeshRenderer>();
        meshr.mesh = nodeMesh;//sets the mesh
        rendr.material = nodeMat;//sets the material
        canShoot = true;
        spawnPoint = transform.GetChild(0).transform;
    }

    void Update()
    {
        if(enemyList.Count >0 && enemyList[0] == null)//this only happens when a tank has been destroyed, gets rid of the empty slot
        {
            enemyList.Remove(enemyList[0]);
        }
        LookAt();
        if(canShoot && enemyList.Count>0)//if it can shoot and there is an enemy in the list, attack
            StartCoroutine(Attack());
    }

    void OnTriggerEnter(Collider col)//the invading units will be tagged as "Invader" unless another naming convention is established
    {
        if(col.gameObject.tag == "Invader")//if what came into range is an invader, add it to the enemy queue
        {
            //Debug.Log("EnemySpotted!");
            enemyList.Add(col.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Invader")
        {
            //Debug.Log("EnemyOutOfSight!");
            enemyList.Remove(col.gameObject);
        }
    }

    void LookAt()
    {
        if(enemyList.Count > 0)
        {
            Vector3 temp = enemyList[0].transform.position;
            temp.y = transform.position.y;
            transform.LookAt(temp);//rotates to look at the first object in the list, if any
        }
    }

    IEnumerator Attack()
    {
        canShoot = false;
        GameObject temp = Instantiate(projectile,spawnPoint.position, spawnPoint.rotation) as GameObject;//spawns the projectile from the turret's position and rotation
        temp.GetComponent<ProjectileScript>().targetTag = "Invader";
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

}

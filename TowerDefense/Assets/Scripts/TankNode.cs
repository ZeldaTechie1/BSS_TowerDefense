using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class TankNode : NodeTemplate {

    public float velocity;
    public float rotationSpeed;
    public Vector3 moveDirection;
    public int index = 0;
    public float precision;
    public Vector3[] waypoints;
    public GameObject enemyBase;
    public bool canShoot;
    public float fireRate;
    public GameObject projectile;
    public Transform spawnPoint;

    Rigidbody rb;

    void Start()//This just sets all the values for all the variables both in this class and the NodeTemplate class
    {
        meshr = GetComponent<MeshFilter>();
        rendr = GetComponent<MeshRenderer>();
        meshr.mesh = nodeMesh;//sets the mesh
        rendr.material = nodeMat;//sets the material
        rb = GetComponent<Rigidbody>();
        enemyBase = GameObject.FindGameObjectWithTag("Base");
        canShoot = true;
        spawnPoint = transform.GetChild(0).transform;
    }

    void FixedUpdate()
    {
        if (index < waypoints.Length)
        {
            Quaternion tempRot = Quaternion.LookRotation(waypoints[index] - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, tempRot, Time.deltaTime * rotationSpeed);//slowly rotates the tank towards the next waypoint
            rb.velocity = transform.forward * velocity;
            if (Vector3.Distance(transform.position, waypoints[index]) < precision)//if the tank is close enough to the waypoint, go to the next one
            {
                index++;
            }
        }
        else//if we are here, that means the tank has reached the base or end of the level
        {
            if(enemyBase!=null)
            {
                rb.velocity = Vector3.zero;
                Vector3 temp = enemyBase.transform.position;
                temp.y = transform.position.y;
                Quaternion tempRot = Quaternion.LookRotation(temp - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, tempRot, Time.deltaTime * rotationSpeed);
                if (canShoot)
                    StartCoroutine(Attack());
            }
        }
    }

    public void SetWaypoints(Vector3[] points)
    {
        waypoints = points;
    }

    IEnumerator Attack()
    {
        Debug.Log("Pew");
        canShoot = false;
        GameObject temp = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation) as GameObject;//spawns the projectile from the tank's position and rotation
        temp.GetComponent<ProjectileScript>().targetTag = "Base";
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}

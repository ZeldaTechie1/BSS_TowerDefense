using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

    public float velocity;
    public float damage;
    public string targetTag;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * velocity;
        Physics.IgnoreLayerCollision(this.gameObject.layer, this.gameObject.layer);//stops collision with other projectiles
        Physics.IgnoreLayerCollision(this.gameObject.layer, 11);//stops the projectile from colliding with the ground, for now
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != targetTag)//if it collides with what shot it, it shouldn't
        {
            //Debug.Log("Please ignore this fool!");
            return;
        }
        Debug.Log("Hit " + col.name);
        Health health = col.GetComponent<Health>();
        if(health != null)//if what was hit has a health component, give it damage
        {
            Debug.Log("Hah take that!");
            health.Damage(damage);
        }
        Destroy(this.gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float hp = 100;

    void Update()
    {
        if(hp<=0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Damage(float damage)//takes away damage, can be modified to include damage modifiers
    {
        hp -= damage;
        Debug.Log(hp);
    }

}

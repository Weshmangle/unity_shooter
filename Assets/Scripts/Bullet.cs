using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float damage;
    protected float radius;
    protected float pierce;

    public DataBullet data;
    
    private void Awake()
    {
        if(data != null)
        {
            damage = data.damage;
            radius = data.radius;
            pierce = data.pierce;
        }
        
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.Translate((Vector3.right * Time.deltaTime * 10));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}

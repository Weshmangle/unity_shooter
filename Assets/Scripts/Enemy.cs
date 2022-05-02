using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float speed = 1;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 direction = Player.Instance.transform.position-transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * speed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player.Instance.takeDamage(1);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float delayBetweenShoot = .00025f;
    public float currentDelay = 0;
    public GameObject prefabBullet;
    [SerializeField] public GameObject firePoint;

    public DataBullet data;
        TypeGun a;

    void Update()
    {
        if(currentDelay >= delayBetweenShoot)
        {
            GameObject instance = Instantiate(prefabBullet, firePoint.transform.position, firePoint.transform.rotation);
            instance.GetComponent<Bullet>().data = data;
            currentDelay = 0;
        }
        else
        {
            currentDelay += Time.deltaTime;
        }
    }
}

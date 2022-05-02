using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float radiusEnemy;
    public GameObject prefabEnemy;

    public float timeOutNextStackEnemy;
    public float countStack;
    
    void Start()
    {
        InvokeRepeating(nameof(GenerateEnemy), 0, 1f);
    }

    private void GenerateEnemy()
    {
        var instance = Instantiate(prefabEnemy);
        var angle = Random.Range(0, 1f) * 2 * Mathf.PI;
        instance.transform.position = new Vector3(Mathf.Cos(angle) * radiusEnemy, Mathf.Sin(angle) * radiusEnemy, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(0,0,0), radiusEnemy);    
    }
}

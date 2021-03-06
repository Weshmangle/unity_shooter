using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    [SerializeField] private float radiusEnemy;
    [SerializeField] private float waves;
    public GameObject prefabEnemy;
    public float timeOutNextStackEnemy;
    public float countStack;
    
    void Start()
    {
        Instance = this;
        Invoke(nameof(GenerateEnemy), timeOutNextStackEnemy);
    }

    private void GenerateEnemy()
    {
        var instance = Instantiate(prefabEnemy);
        var angle = Random.Range(0, 1f) * 2 * Mathf.PI;
        instance.transform.position = transform.position;
        instance.transform.position += new Vector3(Mathf.Cos(angle) * radiusEnemy, 0, Mathf.Sin(angle) * radiusEnemy);
        timeOutNextStackEnemy = timeOutNextStackEnemy - (timeOutNextStackEnemy/2) * Time.deltaTime*10;
        Invoke(nameof(GenerateEnemy), timeOutNextStackEnemy);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusEnemy);
    }
}

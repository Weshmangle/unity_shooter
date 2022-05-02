using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Data/Bullet")]
public class DataBullet : ScriptableObject
{
    public string name;
    public string description;
    public float damage;
    public float radius;
    public float pierce;
}

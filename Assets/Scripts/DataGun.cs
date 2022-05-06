using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Data/Gun")]
public class DataGun : ScriptableObject
{
    public string name;
    public string description;
    public float delayBetweenBullet;
}

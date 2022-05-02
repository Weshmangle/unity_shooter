using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text hitPoint;
    
    void Update()
    {
        hitPoint.text = Player.Instance.hitPoint.ToString();   
    }
}

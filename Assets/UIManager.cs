using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text hitPoint;
    public RectTransform panel;
    
    void Update()
    {
        hitPoint.text = Player.Instance.hitPoint.ToString();

        panel.sizeDelta = new Vector2(Screen.width,Screen.width);
    }
}

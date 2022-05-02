using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Slider slider;
    public float rotationVelocity = 0;
    [SerializeField] private float rotationVelocityMax;
    public float hitPoint = 3;
    public List<Gun> guns = new List<Gun>();

    void Start()
    {
        Instance = this;
        slider.onValueChanged.AddListener(delegate {ValueChangedSlider();});
    }
    
    public void ValueChangedSlider()
    {
        rotationVelocity = (slider.value - .5f) * rotationVelocityMax;
    }

    public void takeDamage(float value)
    {
        hitPoint -= value;
        
        if(hitPoint <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Update()
    {
        Vector3 rotation = Mathf.Deg2Rad * transform.rotation.eulerAngles;
        transform.rotation = Quaternion.EulerAngles(0, 0, (rotationVelocity));
        //transform.rotation = Quaternion.EulerAngles(0, 0, rotation.z + (Time.deltaTime) * (rotationVelocity));
        //transform.rotation = Quaternion.Euler(0, 0, rotation.z + (Time.deltaTime) * (rotationVelocity * Mathf.Rad2Deg));
    }
}

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
    [SerializeField] protected int _score = 0;

    void Start()
    {
        Instance = this;
        slider.onValueChanged.AddListener(delegate {ValueChangedSlider();});
    }

    public int score
    {
        get { return _score ;}
    }

    public void IncrementScore()
    {
        _score += 1;
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
        //RotationAtSlider();
        //AutoRotationSlider();
        LookAtMouseInput();
    }

    public void RotationAtSlider()
    {
        transform.rotation = Quaternion.Euler(0, (rotationVelocity * Mathf.Rad2Deg), 0);
    }

    public void AutoRotationSlider()
    {
        Vector3 rotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, (rotation.y) + (Time.deltaTime*25) * (rotationVelocity), 0);
    }

    public void LookAtMouseInput()
    {
        Vector3 mouse_pos;
        Transform target = transform; //Assign to the object you want to rotate
        Vector3 object_pos;
        float angle;
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        target.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
    }
}

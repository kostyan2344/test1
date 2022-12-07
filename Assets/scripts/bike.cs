using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bike : MonoBehaviour
{
    [SerializeField] int speed_min, speed_max;
    float speed;
    public static event Action gameover;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        gameover?.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        speed = gamemanager.instance.Speed;
        speed = Mathf.Clamp(speed, speed_min, speed_max);
        transform.Translate(0,0,speed*Time.deltaTime);
    }
}

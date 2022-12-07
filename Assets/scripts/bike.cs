using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bike : MonoBehaviour
{
    [SerializeField] int speed_min, speed_max;
    float speed=1;
    public static event Action<string> gameover;
    [SerializeField] GameObject wheel1, wheel2,pedals;
    void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("finish"))
            gameover?.Invoke("Доставка выполнена!");
        else
        gameover?.Invoke("Ты проиграл");
    }
    // Update is called once per frame
    void Update()
    {
        speed = gamemanager.instance.Speed;
        speed = Mathf.Clamp(speed, speed_min, speed_max);
        wheel1.transform.Rotate(Vector3.right*100*speed*Time.deltaTime);
        wheel2.transform.Rotate(Vector3.right*100*speed*Time.deltaTime);
        pedals.transform.Rotate(Vector3.right*100*speed*Time.deltaTime);
        transform.Translate(0,0,speed*Time.deltaTime);
    }
}

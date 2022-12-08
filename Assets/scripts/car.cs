using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    float speed;
    void Start()
    {
        speed = Random.Range(5.5f, 7.5f);
        Destroy(gameObject,5);
    }
    void Update()
    { 
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}

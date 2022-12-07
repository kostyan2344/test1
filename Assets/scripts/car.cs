using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    void Start()
    {
        speed = Random.Range(5.5f, 7.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}

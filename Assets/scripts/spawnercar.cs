using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnercar : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    public static spawnercar instance;
    [SerializeField] GameObject[] cars;
    int index;

    void Start()
    {
        instance= this;
        
        time = Random.Range(2.5f, 5);
        Invoke("spawner", time);
    }
    void spawner()
    {
        index=Random.Range(0, cars.Length);
        GameObject car = Instantiate(cars[index],transform.position,transform.rotation);
        time = Random.Range(1, 5);
        if(!bike.end)
        Invoke("spawner", time);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

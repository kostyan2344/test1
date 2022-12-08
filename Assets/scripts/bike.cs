using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class bike : MonoBehaviour
{
    [SerializeField] int speed_min, speed_max;
    float speed = 1;
    public static event Action<string> gameover;
    public static event Action<bool, Collider> death;
    [SerializeField] GameObject wheel1, wheel2, pedals, vcam,pizza;
    [SerializeField] Transform dot1;
    public static bool end=false;
    private void Start()
    {
        end = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("finish"))
        {
            vcam.SetActive(false);
            transform.DOMove(dot1.position, 1);
            transform.DORotate(new Vector3(0, 90, 0), 1).SetEase(Ease.Linear);
            StartCoroutine(sec("Доставка выполнена!"));
            end = true;
        }
        else
        {
            vcam.SetActive(false);
            death?.Invoke(false, other);
            GetComponent<Collider>().isTrigger= false;
            pizza.GetComponent<Rigidbody>().AddForce((-transform.forward * 10)+ (other.transform.forward * 10), ForceMode.Impulse);
            StartCoroutine(sec("Ты проиграл"));
            end = true;
        }
    }
    IEnumerator sec(string text)
    {
        yield return new WaitForSeconds(1);
        gameover?.Invoke(text);
    }

    void Update()
    {
        speed = gamemanager.instance.Speed;
        speed = Mathf.Clamp(speed, speed_min, speed_max);
        if (!end)
        {
            wheel1.transform.Rotate(Vector3.right * 100 * speed * Time.deltaTime);
            wheel2.transform.Rotate(Vector3.right * 100 * speed * Time.deltaTime);
            pedals.transform.Rotate(Vector3.right * 100 * speed * Time.deltaTime);
            transform.Translate(0, 0, speed * Time.deltaTime);  
        }   
    }
}

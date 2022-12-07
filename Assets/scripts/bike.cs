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
    [SerializeField] GameObject wheel1, wheel2, pedals, vcam;
    [SerializeField] Transform dot1,dot2;
   public static bool end=false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("finish"))
        {
            vcam.SetActive(false);
            end = true;
            transform.DOMove(dot1.position, 2);
            transform.DORotate(new Vector3(0, 90, 0), 2);
            StartCoroutine(sec());
        }
        else
            gameover?.Invoke("Ты проиграл");
    }
    IEnumerator sec()
    {
        yield return new WaitForSeconds(2);
        gameover?.Invoke("Доставка выполнена!");
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

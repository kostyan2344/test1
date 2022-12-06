using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
public class gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] FixedJoystick _joystick;
    int i = 0, j, k = 0;
    public static gamemanager instance;
    float speed;
    public float Speed { get { return speed; } set { speed= value; } }
    void Start()
    {
       instance= this;
        Speed = 5;
    }

    // Update is called once per frame
    void Update()
    {

        if (_joystick.Horizontal <= 1 && _joystick.Horizontal > 0 && _joystick.Vertical > 0 && _joystick.Vertical <= 1) { j = i; i = 1; }
        else if (_joystick.Horizontal <= 1 && _joystick.Horizontal > 0 && _joystick.Vertical < 0 && _joystick.Vertical >= -1) { j = i; i = 2; }
        else if (_joystick.Horizontal < 0 && _joystick.Horizontal >= -1 && _joystick.Vertical < 0 && _joystick.Vertical >= -1) { j = i; i = 3; }
        else if (_joystick.Horizontal < 0 && _joystick.Horizontal >= -1 && _joystick.Vertical > 0 && _joystick.Vertical <= 1) { j = i; i = 4; }
        if (j != i) { print(i);hook(i, j); }
    }
    void hook(int n, int o)
    { 
        if (n > o || (n==1 && o==4)) 
        { 
            k++; 
            if (k == 4) 
            { 
                print("двидение вправо"); 
                k = 0;
                Speed += 0.5f;
            } 
        }
        if (n < o || (n == 4 && o == 1)) { k--; if (k == -4) { print("двидение влево"); k = 0; Speed -= 0.5f; } }
    }
}

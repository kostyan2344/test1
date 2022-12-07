using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] FixedJoystick _joystick;
    int i = 0, j, k = 0,s=5;
    public static gamemanager instance;
    float speed;
    public float Speed { get { return speed; } set { speed = value; } }
    [SerializeField] GameObject panel, box,buttons;
    [SerializeField] Text txt;

    void Start()
    {
       instance= this;
        Speed = 1;
        Time.timeScale = 0;
        StartCoroutine(Countdown());
        bike.gameover += Gameover;
    }
    private void OnDestroy()
    {
        bike.gameover -= Gameover;
    }
    void Gameover(string text)
    {
        Time.timeScale = 0;
        _joystick.gameObject.SetActive(false); 
        box.SetActive(false);
        panel.SetActive(true);
        buttons.SetActive(true);
        txt.fontSize = 60;
        txt.text = text;
    }
    public void restart()
    {
        SceneManager.LoadScene("game");
    }
    public void exit()
    {
        SceneManager.LoadScene("menu");
    }
    IEnumerator Countdown()
    {
        while (s >= 0)
        {
            txt.text = s.ToString();
            yield return new WaitForSecondsRealtime(1f);
            s--;
        }
        panel.SetActive(false);
        Time.timeScale = 1;
    }    
    // Update is called once per frame
    void Update()
    {

        if (_joystick.Horizontal <= 1 && _joystick.Horizontal > 0 && _joystick.Vertical > 0 && _joystick.Vertical <= 1) { j = i; i = 1; }
        else if (_joystick.Horizontal <= 1 && _joystick.Horizontal > 0 && _joystick.Vertical < 0 && _joystick.Vertical >= -1) { j = i; i = 2; }
        else if (_joystick.Horizontal < 0 && _joystick.Horizontal >= -1 && _joystick.Vertical < 0 && _joystick.Vertical >= -1) { j = i; i = 3; }
        else if (_joystick.Horizontal < 0 && _joystick.Horizontal >= -1 && _joystick.Vertical > 0 && _joystick.Vertical <= 1) { j = i; i = 4; }
        if (j != i) { hook(i, j); }
    }
    void hook(int n, int o)
    { 
        if (n > o || (n==1 && o==4)) 
        { 
            k++; 
            if (k == 4) 
            { 
                 
                k = 0;
                Speed += 0.5f;
            } 
        }
        if (n < o || (n == 4 && o == 1)) { k--; if (k == -4) { k = 0; Speed -= 0.5f; } }
    }
}

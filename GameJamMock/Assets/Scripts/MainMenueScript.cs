using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenueScript : MonoBehaviour
{
    public AudioSource Music;
    public Transform Ship;
    public Transform[] Background;
    private float timer;
    

    void Start()
    {
        timer = 0;
        //Music.Play();
    }

    void Update()
    {
        timer += Time.deltaTime;
        ShipMovement();
        MoveBackGround();
    }
    
    void ShipMovement()
    {
        Ship.position = new Vector3(-3, Mathf.Sin(timer), 0);
        Ship.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Sin(timer+1.2f)*20));
    }
    void MoveBackGround()
    {
        for (int i = 0; i< Background.Length; i++ )
        {
            Background[i].position += new Vector3(-1 * Time.deltaTime, 0, 0);

            if (Background[i].position.x <= -20)
            {
                Background[i].position += new Vector3(36, 0, 0);   
            }
        }
    }


    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }


    
}

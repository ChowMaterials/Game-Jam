using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBackground : MonoBehaviour
{
    public Transform Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position)>3000)
        {

            Destroy(gameObject);
            
        }
    }

    void ScaleBackground()
    {
        
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform Player;
    public Transform Background;
    private int LowerBound;
    private int UpperBound;
    
    void Start()
    {
        LowerBound = -748;
        UpperBound = 748;
        GenerateInitialBacground();

    }
    void Update()
    {
        GenerateBackGround();
    }
    
    
    void GenerateInitialBacground()
    {
        var _spawnPosition = new Vector3(0, 48, 125);
        Instantiate(Background, _spawnPosition, Quaternion.identity);
       


    }

    void GenerateBackGround()
    {
             var _spawnPosition = new Vector3(0,0,0);
            if (Player.position.x > UpperBound -600)
            {
            _spawnPosition = new Vector3(UpperBound,48,125);
            Instantiate(Background, _spawnPosition, Quaternion.identity);
            UpperBound += 748;
            
            }
            
            if (Player.position.x <  LowerBound+600)
            {
            _spawnPosition = new Vector3(LowerBound, 48, 125);
            Instantiate(Background, _spawnPosition, Quaternion.identity);
            
            LowerBound -= 748;
        }
        SynchroniseUppaerLowerBound();

    }
    void SynchroniseUppaerLowerBound()
    {
        if (UpperBound - LowerBound >2992)
        {
            if (UpperBound- Player.position.x  < Player.position.x - LowerBound)
            {
                LowerBound += 748;
                
            }
            else
            {
                UpperBound -= 748;
                
            }
        }
    
    }


}

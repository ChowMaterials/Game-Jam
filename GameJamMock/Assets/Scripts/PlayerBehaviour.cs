using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private bool isMoveing;
    private Quaternion facingDirection;
    [SerializeField] float movementSpeed;




    void Start()
    {
        isMoveing = false;
        
    }

    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float _x = Input.GetAxis("Horizontal");
        float _y = Input.GetAxis("Vertical");

        if(_x == 0 && _y ==0){
            isMoveing = false;
        }
        else{
            isMoveing = true;
        }
        Rotation(_x, _y);
        transform.position += new Vector3(_x,_y,0) *Time.deltaTime *movementSpeed;


    }
    void Rotation(float _x, float _y)
    {
        
        if (isMoveing)
        {
            var _facingDir = 1;
            if (_x < 0){
                facingDirection = Quaternion.Euler(new Vector3(0,180,0));
                _facingDir = -1;
            }
            else {
                facingDirection = Quaternion.Euler(new Vector3(0,0,0));
                _facingDir = 1;
            }


            var _angle = Mathf.Atan(_y*3) * Mathf.Rad2Deg;
            if(_y >0){
                _angle -= _x*30 * _facingDir;
            }
            else if(_y < 0){
                _angle += _x * 30* _facingDir;
            }

            transform.rotation = Quaternion.AngleAxis(_angle *_facingDir, Vector3.forward) * facingDirection;

        }
        else{
            transform.rotation = facingDirection;
        }
    }

}

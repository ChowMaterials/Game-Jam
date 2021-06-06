using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public static bool isGrounded = false;
    private bool isMoveing;
    private Quaternion facingDirection;
    [SerializeField] float movementSpeed;




    void Start()
    {
        isMoveing = false;
        
    }

    
    void FixedUpdate()
    {
        
        
        if (!isGrounded)
        {
            AirMovement();
            CheckIfGrounded();
        }
        else
        {
            GroundMovement();
        }
        
    }

    void CheckIfGrounded()
    {
        var _GroundCheckerPosition = new Vector2(transform.position.x, transform.position.y) + new Vector2(0, -2);
        var _GroundCheckerSize = new Vector2(1, 1);
        var _GroundCheckerAngle = 0;
        var _GroundCheckerDirection = new Vector2(0,-1);
        RaycastHit2D hit = Physics2D.BoxCast(_GroundCheckerPosition, _GroundCheckerSize, _GroundCheckerAngle, _GroundCheckerDirection, 2);
        try
        {
            

                if (hit.transform.gameObject.layer == 6)
                {
                    isGrounded = true;
                    InitializeGroundMovement();
                
                }
                else
                {


                return;

                }
            
        }
        catch
        {
            isGrounded = false;
            InitializeAirMovement();
        }
        
        
        
    }
    void InitializeAirMovement()
    {
        var _Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _Rigidbody.gravityScale = 0;
        _Rigidbody.freezeRotation = false;
    }

    void AirMovement()
    {
        float _x = Input.GetAxis("Horizontal");
        float _y = Input.GetAxis("Vertical");
        var _Rigidbody = gameObject.GetComponent<Rigidbody2D>();


        if (_x == 0 && _y ==0){
            isMoveing = false;
        }
        else{
            isMoveing = true;
        }
        AirRotation(_x, _y);
        _Rigidbody.AddForce(new Vector2(_x, _y)*movementSpeed*10);
       


    }
    void AirRotation(float _x, float _y)
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

    void InitializeGroundMovement()
    {
        var _Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _Rigidbody.gravityScale = 1;
        _Rigidbody.freezeRotation = true;
        
        
    }
    void GroundMovement()
    {
        GroundRotation();
        var _x = Input.GetAxis("Horizontal");
        var _y = Input.GetAxis("Vertical");
        var _Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        Jump();
        transform.position += new Vector3(_x,0,0) *Time.deltaTime *movementSpeed;
        
    }

    void Jump()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            CheckIfGrounded();
            var _Rigidbody = gameObject.GetComponent<Rigidbody2D>();
            _Rigidbody.AddForce(new Vector2(0, 1000));
            
        }
    }
    void GroundRotation()
    {
        float _x = Input.GetAxis("Horizontal");

        if (isMoveing)
        {
            var _facingDir = 1;
            if (_x < 0)
            {
                facingDirection = Quaternion.Euler(new Vector3(0, 180, 0));
                _facingDir = -1;
            }
            else
            {
                facingDirection = Quaternion.Euler(new Vector3(0, 0, 0));
                _facingDir = 1;
            }



            transform.rotation = Quaternion.AngleAxis( _facingDir, Vector3.forward) * facingDirection;

        }
        else
        {
            transform.rotation = facingDirection;
        }
    }

}

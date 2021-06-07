using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    
    public Transform Player;
    Vector3 offset;
    Vector2 cameraScale;
    

    void Start()
    {
        offset = new Vector3(0,0,-10);
        cameraScale = new Vector2(0, 0);
    }

    
    void FixedUpdate()
    {
        Movement();
        Scale();
    }

    void Movement()
    {
        transform.position = Vector3.Lerp(transform.position, Player.position + offset, Time.deltaTime*12);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Scale()
    {
        var _CameraScale = GetComponent<Camera>().orthographicSize;
        var _x = Input.GetAxis("Horizontal");
        var _y = Input.GetAxis("Vertical");
        Vector2 _scaleVector = new Vector2(_x, _y);

        _scaleVector.Normalize();
        cameraScale = Vector2.Lerp(cameraScale, _scaleVector, Time.deltaTime*0.5f);
        var _scaleFactor = Mathf.Sqrt(cameraScale.x * cameraScale.x + cameraScale.y * cameraScale.y)*15 +20;
        //GetComponent<Camera>().orthographicSize = _scaleFactor;

        transform.position = new Vector3(transform.position.x, transform.position.y,- _scaleFactor);

        
    }

}

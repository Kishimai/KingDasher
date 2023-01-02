using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _player;

    public Vector3 _CloserOffset;
    public Vector3 _offset;
    public float _smoothSpeed = 0.125f;

    public void FixedUpdate(){
        Vector3 desiredPosition;

        if(Input.GetKey(KeyCode.X)){
            desiredPosition = _player.position + _CloserOffset;
        } else {
            desiredPosition = _player.position + _offset;
        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothedPosition;
    }
    
}

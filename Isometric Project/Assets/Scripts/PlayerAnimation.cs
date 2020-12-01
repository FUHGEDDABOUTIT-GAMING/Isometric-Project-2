using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    // public string[] staticDirections =
    // {
    //     "Static N", "Static NW", "Static N", "Static SW",
    //     "Static S", "Static SE", "Static E", "Static NE"
    // };
    //
    // public string[] runDirections =
    // {
    //     "Run N", "Run NW", "Run N", "Run SW",
    //     "Run S", "Run SE", "Run E ", "Run NE"
    // };

    private int lastDirection;
    // Start is called before the first frame update
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        // float result1 = Vector2.SignedAngle(Vector2.up, Vector2.right);
        // Debug.Log("R1" +result1);
        // float result2 = Vector2.SignedAngle(Vector2.up, Vector2.left);
        // Debug.Log("R1" +result2);
        // float result3 = Vector2.SignedAngle(Vector2.up, Vector2.down);
        // Debug.Log("R1" +result3);
    }

    public void Movement(string direction)
    {
        _anim.Play(direction);
    }


    /*
    public void SetDirection(Vector2 _direction)
    {
        string[] directionArray=null;
        Debug.Log(_direction.magnitude);
        if (_direction.magnitude < 0.05)
        {
            directionArray = staticDirections;
        }
        else
        {
            directionArray = runDirections;
            lastDirection = DirectionToIndex(_direction);
        }

        
        _anim.Play(directionArray[lastDirection]);
    }
    */

    /*private int DirectionToIndex(Vector2 _direction)
    {
        Vector2 norDir = _direction.normalized;
        float step = 360 / 8;
        float offset = step / 2;
        
        float angle = Vector2.SignedAngle(Vector2.up, norDir);

        angle += offset;
        if (angle < 0)
        {
             angle += 360;
        }

        float stepCount = angle / step;
        //Debug.Log(stepCount);
        return Mathf.FloorToInt(stepCount);
        return Mathf.FloorToInt(stepCount);
    }*/
}

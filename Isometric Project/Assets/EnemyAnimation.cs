using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _anim;

    private int lastDirection;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Movement(string direction)
    {
        _anim.Play(direction);
    }

}

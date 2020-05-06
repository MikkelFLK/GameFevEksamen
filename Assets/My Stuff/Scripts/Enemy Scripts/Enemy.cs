using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anima;

    protected virtual void Start()
    {
        anima = GetComponent<Animator>();
    }

    public void JumpedOn()
    {
        anima.SetTrigger("Death");
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
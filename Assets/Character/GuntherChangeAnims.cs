using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GuntherChangeAnims : MonoBehaviour

{
    private Animator anim;

    // Start is called before the first frame update
    
    void Start()
    {
        anim=GetComponent <Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad0))
        {
            anim.SetBool("IsJump",true);
        }
        else
        {
            anim.SetBool("IsJump",false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("IsRun",true);
            anim.SetBool("IsIdle",false);
        }
        else
        {
            anim.SetBool("IsRun",false);
            anim.SetBool("IsIdle",true);
        }
    }
}

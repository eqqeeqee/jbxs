using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimation : HeroBase
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("facingTo",facingTo);
        anim.SetBool("grounded", grounded);
        anim.SetBool("climbing", climbing);
        anim.SetFloat("hspeed", hSpeed);
    }

    private void FixedUpdate()
    {
        anim.SetFloat("vspeed", vSpeed);
    }
}

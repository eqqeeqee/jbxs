using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : HeroBase
{
    Vector2 groundCheckerLeft;
    Vector2 groundCheckerRight;
    public Transform groundCheckPosition;
    public LayerMask backDrop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //检测角色脚下有没有地面
        groundCheckerLeft = new Vector2(groundCheckPosition.transform.position.x - 0.12f, groundCheckPosition.transform.position.y);
        groundCheckerRight = new Vector2(groundCheckPosition.transform.position.x + 0.12f, groundCheckPosition.transform.position.y);
        if (Physics2D.OverlapCircle(groundCheckerLeft, 0.001f,backDrop)|| Physics2D.OverlapCircle(groundCheckerRight, 0.001f,backDrop))
            grounded = true;
        else
            grounded = false;
    }
}

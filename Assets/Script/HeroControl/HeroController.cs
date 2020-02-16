using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : HeroBase
{
    private float hAxis;//水平Axis
    public Rigidbody2D heroRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //控制垂直移动
        if (soulInside)
        {
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                if (climbing == false)
                {
                    heroRigidbody.velocity = new Vector2(heroRigidbody.velocity.x, jumpSpeed);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        
        //控制面朝方向
        if (soulInside)
        {
            hAxis = Input.GetAxis("Horizontal");
            if (hAxis < -0.01)
            {
                facingTo = false;
                if (Input.GetKey(KeyCode.D))
                    facingTo = true;
            }
            if (hAxis > 0.01)
            {
                facingTo = true;
                if (Input.GetKey(KeyCode.A))
                    facingTo = false;
            }
            //控制水平移动
            if (facingTo)
                hSpeed = Mathf.Abs(hAxis * runSpeed);
            else
                hSpeed = Mathf.Abs(hAxis * runSpeed) * -1;

            heroRigidbody.velocity = new Vector2(hSpeed, heroRigidbody.velocity.y);
            //记录水平速度
            hSpeed = heroRigidbody.velocity.x;
            //记录垂直速度
            vSpeed = heroRigidbody.velocity.y;

            
            //按 R 键发射灵魂
            if (Input.GetKey(KeyCode.R))
            {
                SoulBase.launch = true;
                SoulController.launcherPosition = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
                soulInside = false;
            }
        }

    }
}

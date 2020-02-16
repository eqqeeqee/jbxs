using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulController : SoulBase
{
    public SpriteRenderer soulSpriteRender;
    private float hAxis;//水平Axis
    private float vAxis;//垂直Axis
    private float instantaneousSpeed; // 瞬时速度
    private float distance; // 移动距离
    private Color soulColor; // 灵魂透明度
    public static Vector2 launcherPosition;//发射体位置
    public CircleCollider2D soulCollider;
    public BoxCollider2D heroBoxCollider;
    public CircleCollider2D heroCircleCollider;
    // Start is called before the first frame update
    void Start()
    {
        soulSpriteRender.color = new Color(255f, 255f, 255f, 0f); //开始不显示
        soulColor = new Color(255f, 255f, 255f, 200f);
        Physics2D.IgnoreCollision(soulCollider, heroBoxCollider, true);
        Physics2D.IgnoreCollision(soulCollider, heroCircleCollider, true);
        launcherPosition = new Vector2();
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        // 如果发射
        if (launch) 
        {
            soulTransform.position = launcherPosition; // 转移到发射器位置
            soulSpriteRender.color = soulColor; //调出颜色
            launch = false;
            soulOutSide = true;
            distance = 0;// 初始化移动距离
        }
        if (possess) // 如果附体
        {
            soulTransform.position = heroTransform.position;//转移到英雄位置
            soulSpriteRender.color = new Color(255f, 255f, 255f, 0f); //淡化颜色
            possess = false;
            soulOutSide = false;
        }
        if (soulOutSide)
        {
            hAxis = Input.GetAxis("Horizontal");
            vAxis = Input.GetAxis("Vertical");
            //控制瞬时速度
            if (hAxis != 0 || vAxis != 0)
            {
                if (instantaneousSpeed < soulRunSpeed)
                {
                    instantaneousSpeed += soulAcceleration * Time.deltaTime;
                }
            }
            else
            {
                instantaneousSpeed = 0;
            }
            //控制方向速度
            //a^2+b^2=i^2,b=sqrt(i^2*b^2/((a^2+b^2))
            if (hAxis == 0 && vAxis == 0)
            {
                soulHSpeed = 0;
                soulVSpeed = 0;
            }
            else
            {
                soulHSpeed = instantaneousSpeed * hAxis / Mathf.Sqrt(hAxis * hAxis + vAxis * vAxis);
                soulVSpeed = instantaneousSpeed * vAxis / Mathf.Sqrt(hAxis * hAxis + vAxis * vAxis);
            }


            GetComponent<Rigidbody2D>().velocity = new Vector2(soulHSpeed, soulVSpeed);

            //控制移动距离与能量的关系(0.625*d^2)
            distance += instantaneousSpeed * Time.deltaTime;
            soulPower = soulMaxPower - 0.625f * distance * distance;
            //随着能量降低，灵魂颜色变浅（15--200）
            soulSpriteRender.color = new Color(255f, 255f, 255f, 200f - (185f * soulPower / soulMaxPower));


        }


    }
}

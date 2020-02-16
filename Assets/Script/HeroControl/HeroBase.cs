using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBase : MonoBehaviour
{
    public Transform heroTransform; //位置
    public static bool facingTo; //面朝方向，true为右
    public static float hSpeed; //水平速度
    public static float vSpeed; //垂直速度
    public static float runSpeed=4f;//跑步速度
    public static float jumpSpeed=7.3f;//跳跃速度
    public static float climbSpeed = 3f;  //爬梯子速度
    public static bool grounded;//是否着陆
    public static bool climbing=false;//是否正在攀爬
    public static bool soulInside=true;// 是否有魂
    public static bool live;//是否活着

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
    }
}

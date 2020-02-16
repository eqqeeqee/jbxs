using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBase : MonoBehaviour
{
    public Transform heroTransform;
    public Transform soulTransform;
    public static bool soulOutSide=false; //魂在不在外面
    public static bool launch;  //是否发射（瞬时）
    public static bool possess;//是否附体（瞬间）
    public static bool soulFacingTo;// 魂朝向
    public static float soulHSpeed;//水平瞬时速度
    public static float soulVSpeed;//垂直瞬时速度
    public static float soulRunSpeed = 3f;//最大速度
    public static float soulAcceleration = 4.5f;//加速度
    public static float soulMaxPower; // 能量上限
    public static float soulPower; //瞬时能量
    public static int[] soulSkillList =new int[0];//技能


    // Start is called before the first frame update
    void Start()
    {
        soulPower = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

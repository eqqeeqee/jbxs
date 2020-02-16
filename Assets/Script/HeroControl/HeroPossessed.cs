using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroPossessed : MonoBehaviour
{
    public static bool canBePossessed;
    public static bool objectSellect;
    public bool selected;// 是否被灵魂选中
    // Start is called before the first frame update

    private void Start()
    {
        canBePossessed = false;
        objectSellect = false;
        selected = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Soul")//灵魂进入附体范围
        {
            Debug.Log("SoulEnter");
            canBePossessed = true;
            if (objectSellect)
            {
                ButtonF.objectPosition = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
                ButtonF.FAppear = true;//满足条件显示F按键提示
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Soul")//灵魂离开附体范围
        {
            canBePossessed = false;
            ButtonF.FDisappear = true;
        }
        
    }


    private void Update()
    {
        if (objectSellect && canBePossessed)//如果满足条件
        {
            if (Input.GetKeyDown(KeyCode.F))//按下F时
            {
                HeroBase.soulInside = true;//附身并更改一系列条件
                SoulBase.soulOutSide = false;
                SoulController.possess = true;
                canBePossessed = false;
                objectSellect = false;
                ButtonF.FDisappear = true;
            }
        }
    }


}

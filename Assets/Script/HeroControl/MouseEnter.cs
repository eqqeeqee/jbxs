using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEnter : HeroPossessed
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseEnter()
    {
        if (SoulBase.soulOutSide)//鼠标进入选择范围
        {
            Debug.Log("MouseEnter");
            objectSellect = true;
            if (canBePossessed)
            {
                ButtonF.objectPosition = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
                ButtonF.FAppear = true;//满足条件显示F按键提示
            }
        }
    }
    private void OnMouseExit()
    {
        if (SoulBase.soulOutSide)//鼠标离开选择范围
        {
            objectSellect = false;
            ButtonF.FDisappear = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonF : ButtonBase
{
    public static bool FAppear; // 出现瞬间
    public static bool FDisappear; // 消失瞬间
    public static Vector3 objectPosition; // 出现的目标位置
    // Start is called before the first frame update
    void Start()
    {
        FAppear = false;
        FDisappear = false;
        buttonTransform.position = new Vector3(buttonTransform.position.x, buttonTransform.position.y, -20);
    }

    // Update is called once per frame

    private void Update()
    {
        if (FAppear)
        {
            buttonTransform.position = new Vector3(objectPosition.x, objectPosition.y + 0.6f, -4);
            FAppear = false;
        }
        if (FDisappear)
        {
            buttonTransform.position = new Vector3(objectPosition.x, objectPosition.y + 0.6f, -20);
            FDisappear = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowed : HeroBase
{
    private Vector3 centerPosition;//屏幕中心位置
    public static int centerMoveH=0;//中心水平大格移动
    public static int centerMoveV=0;//中心垂直大格移动
    public Transform cameraTransform;
    
    // Start is called before the first frame update
    void Awake()
    {
        centerMoveH = 0;
        centerMoveV = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //镜头随主角走出场景跟随主角切换场景
        if (heroTransform.position.x > centerPosition.x + 20 / 3f)
            centerMoveH++;
        if (heroTransform.position.x < centerPosition.x - 20 / 3f)
            centerMoveH--;
        if (heroTransform.position.y > centerPosition.y + 5)
            centerMoveV++;
        if (heroTransform.position.y < centerPosition.y - 5)
            centerMoveV--;

        centerPosition = new Vector3(centerMoveH * 40 / 3f, centerMoveV * 10,-10);
        cameraTransform.position = centerPosition;
    }
}

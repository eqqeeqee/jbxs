using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    public static bool stepOn = false;
    public static float breakTime = 1f;
    public Collider2D OwnCollider2D;
    public BoxCollider2D HeroBoxCollider2D;
    public CircleCollider2D HeroCircleCollider2D;
    public Transform FPtransform;
    public Animator anim;
    public LayerMask OriginalLayer;
    public LayerMask InvisibleLayer;
    public static int HWorldLocation;
    public static int VWorldLocation;


    private void Awake ()
    {

    }
    private void FixedUpdate()
    {
        if (stepOn)
        {

            anim.SetBool("stepOn", stepOn);
            breakTime -= Time.deltaTime;
            if (breakTime <= 0)
            {
                FPtransform.position = new Vector3(FPtransform.position.x, FPtransform.position.y, -20f);
                gameObject.layer = 11;
                stepOn = false;
                Physics2D.IgnoreCollision(OwnCollider2D, HeroBoxCollider2D, true);
                Physics2D.IgnoreCollision(OwnCollider2D, HeroCircleCollider2D, true);
                breakTime = 1f;
                anim.SetBool("stepOn", stepOn);
            }
        }
        if (CameraFollowed.centerMoveH != HWorldLocation || CameraFollowed.centerMoveV != VWorldLocation)
        {
            FPtransform.position = new Vector3(FPtransform.position.x, FPtransform.position.y, 0);
            gameObject.layer = 9;
            Physics2D.IgnoreCollision(OwnCollider2D, HeroBoxCollider2D, false);
            Physics2D.IgnoreCollision(OwnCollider2D, HeroCircleCollider2D, false);
        }
       

    }
}

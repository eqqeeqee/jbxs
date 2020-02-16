using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : HeroBase
{
    public Collider2D ladderContact;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.GetComponent<BoxCollider2D>(), ladderContact, true);
            Physics2D.IgnoreCollision(collision.GetComponent<CircleCollider2D>(), ladderContact, true);
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (Input.GetKey(KeyCode.W))
            {
                climbing = true;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, climbSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                climbing = true;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -climbSpeed);
            }
            else
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            climbing = false;
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), ladderContact, false);
            Physics2D.IgnoreCollision(collision.GetComponent<CircleCollider2D>(), ladderContact, false);
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }


}

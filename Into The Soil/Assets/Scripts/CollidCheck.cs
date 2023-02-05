using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidCheck : MonoBehaviour
{
    public delegate void CollidAction(Collider2D other);
    public CollidAction OnColliderEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnColliderEnter != null)
            OnColliderEnter(collision);

        if (collision.tag.Contains("Tail"))
        {
            GameObject.Find("Health Bar").GetComponent<Health>().killPlayer();
        }

    }
}

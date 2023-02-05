using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float minimum = -0.4F;
    float maximum = 0.4F;
    float t = 0.0f;
    public float speed = 0.25f;
    public bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        if(!canMove)
        {
            return;
        }

        transform.localPosition = new Vector3(Mathf.Lerp(minimum, maximum, t), transform.localPosition.y, 0);

        t += speed * Time.deltaTime;

        if (t > 1.0f)
        {
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
        /*
        if (speed >= 0)
        {
            gameObject.transform.localScale.Set(0.6f, 0.6f, 1f);
        }
        else
        {
            gameObject.transform.localScale.Set(-0.6f, 0.6f, 1f);
        }
        */
    }
}

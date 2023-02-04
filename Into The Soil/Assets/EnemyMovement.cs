using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float minimum = -0.4F;
    float maximum = 0.4F;
    float t = 0.0f;
    public float speed = 0.25f;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(Mathf.Lerp(minimum, maximum, t), transform.position.y, 0);

        t += speed * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}

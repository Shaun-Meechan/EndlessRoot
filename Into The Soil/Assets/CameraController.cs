using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 2.5f;
    bool canMove = true;
    bool shouldReverse = false;
    // Update is called once per frame
    void Update()
    {
        if(!canMove)
        {
            return;
        }

        if(shouldReverse)
        {
            transform.SetPositionAndRotation(new Vector3(0, transform.position.y + (speed * Time.deltaTime), -10), Quaternion.identity);
            if(transform.position.y >= 0)
            {
                canMove = false;
            }
            return;
        }
        transform.SetPositionAndRotation(new Vector3(0, transform.position.y - (speed * Time.deltaTime), -10), Quaternion.identity);
    }

    public void stopMoving()
    {
        canMove = false;
    }

    public void startMoving()
    {
        canMove = true;
    }

    public void reverse()
    {
        shouldReverse = true;
    }


}

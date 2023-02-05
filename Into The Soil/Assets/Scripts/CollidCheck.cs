using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidCheck : MonoBehaviour
{
    public delegate void CollidAction(Collider2D other);
    public CollidAction OnColliderEnter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnColliderEnter != null)
            OnColliderEnter(collision);
        //Debug.LogError("something collide");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAutoDestroyer : MonoBehaviour
{
    public float delay = 0f;

    // Use for initialization
    void Start()
    {
        Destroy(gameObject.transform.parent.gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}

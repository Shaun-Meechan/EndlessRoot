using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TailGeneration : MonoBehaviour
{
    private SpriteShapeController tails;

    [SerializeField]
    private int pivot = 1;
    public int Pivot => pivot;
    private CustomTimer generateTimer;

    // Start is called before the first frame update
    void Start()
    {
        //generateTimer.StartTimer(1, );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialise()
    {
        tails = GetComponent<SpriteShapeController>();
        generateTimer = gameObject.AddComponent<CustomTimer>();
    }

    void InsertPointInRoot(Vector2 loc)
    {
        tails.spline.InsertPointAt(pivot, loc);
        pivot++;
    }

    
}

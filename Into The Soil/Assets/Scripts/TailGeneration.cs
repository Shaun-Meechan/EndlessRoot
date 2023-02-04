using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using Random = UnityEngine.Random;

public class TailGeneration : MonoBehaviour
{
    [SerializeField]
    private SpriteShapeController tails;

    private EdgeCollider2D edgeCollider;


    [SerializeField]
    private int pivot = 1;
    public int Pivot => pivot;
    private CustomTimer generateTimer;

    [SerializeField]
    private GameObject rootCap;

    // Start is called before the first frame update
    void Start()
    {
        Initialise();   
        //generateTimer.StartTimer(0.1f, InsertPointAtSecondLastIndex, true);
    }

    // Update is called once per frame
    void Update()
    {
        FollowRootCap();
    }

    void Initialise()
    {
        tails = GetComponent<SpriteShapeController>();
        generateTimer = gameObject.AddComponent<CustomTimer>();
        if (rootCap == null)
            rootCap = GameObject.FindGameObjectWithTag("Player");

        pivot = tails.spline.GetPointCount() - 1;
        rootCap.GetComponent<RootMovement>().OnDirChange = InsertPointAtSecondLastIndex;
        edgeCollider = GetComponent<EdgeCollider2D>();
    }


    void GetLastPoint()
    {
        int totalNum = tails.spline.GetPointCount();
        Vector3 startPoint = transform.position + tails.spline.GetPosition(totalNum - 1);
        Vector3 endPoint = transform.position + tails.spline.GetPosition(totalNum - 1) + new Vector3(0,100,0);
        if (totalNum > 2)
            Debug.DrawLine(startPoint, endPoint, Color.red,100, true);
        else
            Debug.LogError("Num <= 2");
    }

    void FollowRootCap()
    {
        tails.spline.SetPosition(pivot, rootCap.transform.position - transform.position);
    }

    void InsertPointAtSecondLastIndex(Dir dir)
    {
        Vector3 direction = new Vector3(0, 0, 0);
        switch(dir)
        {
            case Dir.Up: direction = new Vector3(0, 0.05f, 0); break;
            case Dir.Down: direction = new Vector3(0, -0.05f, 0); break;
            case Dir.Left: direction = new Vector3(-0.05f, 0, 0); break;
            case Dir.Right: direction = new Vector3(0.05f, 0, 0); break;
            default: break;
        }            
        Vector3 currentLoc = tails.spline.GetPosition(pivot) - direction;
        tails.spline.InsertPointAt(pivot, currentLoc);
        tails.spline.SetHeight(pivot, Random.Range(0.4f, 0.6f));
        tails.spline.SetTangentMode(pivot, ShapeTangentMode.Continuous);
        pivot++;
        //InsertPointInEdgeCollider(currentLoc);
    }
    void InsertPointInEdgeCollider(Vector3 loc)
    {
        List<Vector2> temp = new List<Vector2>();
        edgeCollider.GetPoints(temp);
        temp.Add(loc);
        edgeCollider.SetPoints(temp);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class CustomGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject rootContainer;

    List<GameObject> rootContrainers = new List<GameObject>();

    private void Start()
    {
        RedrawRoots();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (Input.GetKeyDown(KeyCode.V))
            RedrawRoots();
    }
    public void RestartGame()
    {
        GameObject tail = GameObject.FindGameObjectWithTag("Tail");
        RootDataKeeper.StoreShape(tail.GetComponent<SpriteShapeController>().spline);
        Debug.LogError(RootDataKeeper.GetNumOfShape());
        tail.GetComponent<TailGeneration>().SetIsAllowedFollow(false);
        SceneManager.LoadScene("Mechanics Testing 2");
    }

    public void saveTail()
    {
        GameObject tail = GameObject.FindGameObjectWithTag("Tail");
        RootDataKeeper.StoreShape(tail.GetComponent<SpriteShapeController>().spline);
        tail.GetComponent<TailGeneration>().SetIsAllowedFollow(false);
    }

    void RedrawRoots()
    {
        List<Spline> AllRoots = RootDataKeeper.GetAllRoots();
        foreach (Spline root in AllRoots)
        {
            GameObject thisRoot = GameObject.Instantiate(rootContainer);
            for(int i = 2; i < root.GetPointCount()-1; i++)
            {
                Spline rootSpline = thisRoot.GetComponent<SpriteShapeController>().spline;
                rootSpline.InsertPointAt(i, root.GetPosition(i));
                rootSpline.SetHeight(i, Random.Range(0.4f, 0.6f));
                rootSpline.SetTangentMode(i, ShapeTangentMode.Continuous);
            }
            int last = root.GetPointCount()-1;
            Spline lastSpline = thisRoot.GetComponent<SpriteShapeController>().spline;
            lastSpline.SetPosition(last, root.GetPosition(last));
            lastSpline.SetHeight(last, 0.2f);
            lastSpline.SetLeftTangent(last, new Vector3(0, 1, 0));
            thisRoot.SetActive(false);
            rootContrainers.Add(thisRoot);
        }
    }

    public void showRoots()
    {
        for (int i = 0; i < rootContrainers.Count; i++)
        {
            rootContrainers[i].SetActive(true);
        }
    }
}

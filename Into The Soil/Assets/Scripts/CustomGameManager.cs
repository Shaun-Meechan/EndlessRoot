using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class CustomGameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    public void RestartGame()
    {
        RootDataKeeper.StoreShape(GameObject.FindGameObjectWithTag("Tail").GetComponent<SpriteShapeController>().spriteShape);
        Debug.LogError(RootDataKeeper.GetNumOfShape());
        SceneManager.LoadScene("TestLevel");
    }
}

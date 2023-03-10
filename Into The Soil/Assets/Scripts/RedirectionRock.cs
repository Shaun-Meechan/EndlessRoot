using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RedirectionRock : MonoBehaviour
{
    private Health playerHealth;

    public GameObject getNextRock() { return nextRock; }
    public void setNextRock(GameObject next) { nextRock = next; }
    GameObject nextRock;

    bool isBehind = false;
    public bool getIsBehind() { return isBehind; }
    public void setIsBehind(bool value) { isBehind = value; }

    [SerializeField]
    private GameObject FX;

    [SerializeField]
    private GameObject DestroyFX;

    private void Start()
    {
        playerHealth = FindObjectOfType<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        Vector2 newDir = new Vector2();
        if (collision.gameObject.tag.Contains("Player"))
        {
            if (playerHealth.healthCanBeDrained)
            {
                collision.gameObject.GetComponent<RootMovement>().Stun();
                CreateFX(ChooseCloserDir(contact.normal));
                RootMovement movement = collision.gameObject.GetComponent<RootMovement>();
                newDir = Vector2.Reflect(movement.direction, ChooseCloserDir(contact.normal).normalized);
                Dir nextDir = Dir.Down;
                switch (newDir.normalized)
                {
                    case var value when value == Vector2.down: nextDir = Dir.Down; break;
                    case var value when value == Vector2.up: nextDir = Dir.Up; break;
                    case var value when value == Vector2.right: nextDir = Dir.Right; break;
                    case var value when value == Vector2.left: nextDir = Dir.Left; break;
                    default: Debug.LogError("direction undefined."); break;
                }
                movement.ChangeDirection(nextDir);
            }
            else
            {
                GameObject.Instantiate(DestroyFX, transform.position, Quaternion.FromToRotation(Vector3.zero, Vector3.zero));

                //Destroy(gameObject);
                setIsBehind(true);
            }
            
        }
        
        else
            Debug.LogError("collision undefined!");
    }
    private Vector2 ChooseCloserDir(Vector2 normal)
    {
        List<Vector2> fourNormal = new List<Vector2>();
        fourNormal.Add(new Vector2(1, 1));
        fourNormal.Add(new Vector2(-1, 1));
        fourNormal.Add(new Vector2(-1, -1));
        fourNormal.Add(new Vector2(1, -1));
        int flag = 0;
        int minFlag = 0;
        float tempMax = 0;
        foreach (Vector2 v in fourNormal)
        {
            float temp = Vector2.Dot(normal, v);
            if (temp < tempMax)
            { 
                tempMax = temp;
                minFlag = flag;
            }
            flag++;
        }
        //Debug.LogError(fourNormal[minFlag]);
        return fourNormal[minFlag];
    }
    void CreateFX(Vector2 normal)
    {
        Vector3 upDir = new Vector3(0, 1, 0);
        Vector3 nor = new Vector3(normal.x, normal.y, 0);
        GameObject.Instantiate(FX, transform.position, Quaternion.FromToRotation(upDir,nor));
    }
}

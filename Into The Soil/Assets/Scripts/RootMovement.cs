using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Dir
{
    Up, Down, Left, Right, err
}

public class RootMovement : MonoBehaviour
{
    //config
    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private Vector2Int direction;

    private Dir currentDir;

    // Start is called before the first frame update
    void Start()
    {
        Initialise();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeDirection(Dir.Up);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeDirection(Dir.Down);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeDirection(Dir.Right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeDirection(Dir.Left);
        }

        Move();
    }

    void Initialise()
    {
        direction = new Vector2Int(0, -1);
        currentDir = Dir.Down;
    }

    void Move()
    {
        float currentX, currentY;
        float newX, newY;
        currentX = transform.position.x;
        currentY = transform.position.y;

        newX = currentX + speed * Time.deltaTime * direction.x;
        newY = currentY + speed * Time.deltaTime * direction.y;

        transform.position = new Vector2(newX, newY);
    }

    void ChangeDirection(Dir dir)
    {
        if (dir == currentDir)
            return;
        if (dir == GetOpposite(currentDir))
            return;
        switch(dir)
        {
            case Dir.Up: direction = new Vector2Int(0, 1) ; currentDir = Dir.Up; break;
            case Dir.Down:direction = new Vector2Int(0, -1); currentDir = Dir.Down; break;
            case Dir.Right:direction = new Vector2Int(1, 0); currentDir = Dir.Right; break;
            case Dir.Left: direction = new Vector2Int(-1, 0); currentDir = Dir.Left; break;    
            default: break;
        }
    }

    Dir GetOpposite(Dir dir)
    {
        switch (dir)
        {
            case Dir.Up: return Dir.Down;
            case Dir.Down: return Dir.Up;
            case Dir.Right: return Dir.Left;
            case Dir.Left: return Dir.Right;
            default: return Dir.err;
        }
    }
}

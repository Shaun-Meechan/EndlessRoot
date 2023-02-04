using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dir
{
    Up, Down, Left, Right, err
}

public class RootMovement : MonoBehaviour
{
    public delegate void Action(Dir lastDir);
    //config
    [SerializeField]
    private float speed = 3.0f;

    public Vector2Int direction;

    private Dir currentDir;

    public Action OnDirChange;

    private CameraController cameraController;

    public bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        Initialise();

        cameraController = Camera.main.GetComponent<CameraController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!canMove)
        {
            return;
        }

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

    public void playerDied()
    {
        canMove = false;
        ChangeDirection(Dir.Down);
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
        if (OnDirChange != null)
            OnDirChange(currentDir);
        switch(dir)
        {
            case Dir.Up: direction = new Vector2Int(0, 1) ; currentDir = Dir.Up; transform.eulerAngles = new Vector3(0,0,180); cameraController.stopMoving(); break;
            case Dir.Down:direction = new Vector2Int(0, -1); currentDir = Dir.Down; transform.eulerAngles = new Vector3(0, 0, 0); cameraController.startMoving(); break;
            case Dir.Right:direction = new Vector2Int(1, 0); currentDir = Dir.Right; transform.eulerAngles = new Vector3(0, 0, 90); cameraController.stopMoving(); break;
            case Dir.Left: direction = new Vector2Int(-1, 0); currentDir = Dir.Left; transform.eulerAngles = new Vector3(0, 0, -90); cameraController.stopMoving(); break;    
            default: break;
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
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

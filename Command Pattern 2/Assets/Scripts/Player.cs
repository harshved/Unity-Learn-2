using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    ICommand moveUp, moveLeft, moveRight, moveDown;
    private float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            moveUp = new MoveUpCommand(this.transform, speed);
            moveUp.Execute();
            CommandManager.Instance.AddCommand(moveUp);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            moveDown = new MoveDownCommand(this.transform, speed);
            moveDown.Execute();
            CommandManager.Instance.AddCommand(moveDown);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            moveLeft = new MoveLeftCommand(this.transform, speed);
            moveLeft.Execute();
            CommandManager.Instance.AddCommand(moveLeft);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            moveRight = new MoveRightCommand(this.transform, speed);
            moveRight.Execute();
            CommandManager.Instance.AddCommand(moveRight);
        }

    }
}

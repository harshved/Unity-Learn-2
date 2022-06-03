using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CommandManager : MonoBehaviour
{
    private static CommandManager instance;
    public static CommandManager _instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("The Command is Null");

            return instance;
        }
    }

    private List<ICommand> commandBuffer = new List<ICommand>();

    private void Awake()
    {
        instance = this;
    }

    public void AddCommand(ICommand command)
    {
        commandBuffer.Add(command);
    }

    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

    IEnumerator PlayRoutine()
    {
        Debug.Log("Playing...");
        
        foreach(var command in commandBuffer)
        {
            command.Exectue();
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void Rewind()
    {
        StartCoroutine(RewindRoutine());
    }

    IEnumerator RewindRoutine()
    {
        foreach(var command in Enumerable.Reverse(commandBuffer))
        {
            command.Undo();
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void Done()
    {
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach(var cube in cubes)
        {
            cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    public void Reset()
    {
        commandBuffer.Clear();
    }
}


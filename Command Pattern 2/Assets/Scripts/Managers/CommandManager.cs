using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CommandManager : MonoBehaviour
{
    private static CommandManager _instance;
    public static CommandManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("The CommandManager is Null");
            }
            return _instance;
        }
    }    
    private List<ICommand> commandBuffer = new List<ICommand>();

    private void Awake()
    {
        _instance = this;
    }
    public void AddCommand(ICommand command)
    {
        commandBuffer.Add(command);
    }

    public void Rewind()
    {
        StartCoroutine(RewindRoutine());
    }

    IEnumerator RewindRoutine()
    {
        Debug.Log("Rewinding...");

        foreach (var command in Enumerable.Reverse(commandBuffer))
        {
            command.Undo();
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Finished...");
    }

    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

    IEnumerator PlayRoutine()
    {
        Debug.Log("Playing...");

        foreach (var command in commandBuffer)
        {
            command.Execute();
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Finished...");
    }
}

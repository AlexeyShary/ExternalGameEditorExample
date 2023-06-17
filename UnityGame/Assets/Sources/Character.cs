using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string CharacterName { get; set; }
    public List<string> CharacterActions { get; } = new List<string>();

    private void OnMouseDown()
    {
        foreach (var action in CharacterActions)
        {
            ParseAction(action);
        }
    }

    private void ParseAction(string action)
    {
        switch (action.Split(" ")[0])
        {
            case "SAY":
                Debug.Log(action.Split(" ")[1]);
                break;
            
            case "SCALE":
                transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2);
                break;
            
            case "HIDE":
                gameObject.SetActive(false);
                break;
            
            default:
                throw new Exception("Unexpected character action " + action);
        }
    }
}
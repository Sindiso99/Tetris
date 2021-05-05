using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownHandler : MonoBehaviour
{
    private SaveGame saveGame;
    // Start is called before the first frame update
    void Start()
    {
        saveGame = GetComponent<SaveGame>();
    }

    public void HandleInputData(int val)
    {
        int index = val;
        saveGame.changeDifficulty(index + 1);
        }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int difficulty;
    public int highscore;
    public string name;

    public PlayerData(Player player)
    {
        name = player.userName;
        difficulty = player.difficulty;
        highscore = player.GetHighScore();



    }
}

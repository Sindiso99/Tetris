using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LeaderBoard
{
    public static int topMax = 5;
    public int[] highScores = new int[topMax];
    public string[] highNames = new string[topMax];

    public LeaderBoard()
    {
        initialiseLeaderBoard();
    }
    public void compareScore(PlayerData player)
    {
        int index = topMax;
        bool beaten = true;
        while (beaten == true && index > 0)
        {
            if (player.highscore > highScores[index-1])
            {
                Debug.Log("New HighScore");
                index--;
            } else
            {
                beaten = false;
            }
        }
        Debug.Log(index);
        if (index < topMax)
        {
            addHighScore(index, player.highscore, player.name);
        }
        
    }

    private void addHighScore(int pos, int scoreInsert, string nameInsert)
    {
        for(int x = pos; x < topMax; x++)
        {
            int temp = highScores[x];
            string tempName = highNames[x];
            highScores[x] = scoreInsert;
            highNames[x] = nameInsert;
            scoreInsert = temp;
            nameInsert = tempName;
        }
    }

    private void initialiseLeaderBoard()
    {
        for(int x = 0; x < topMax; x++)
        {
            highNames[x] = "Open Spot";
        }
    }

    public string NamesToString()
    {
        string names = "";

        for (int x = 0; x < topMax; x++)
        {
            names += highNames[x] + "\n";
        }
        return names;
    } 

    public string ScoresToString()
    {
        string scores = "";

        for (int x = 0; x < topMax; x++)
        {
            scores += highScores[x].ToString() + "\n";
        }
        return scores;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour 
{
    public InputField textBox;


    public void clickReadyButton()
    {
        if (!string.IsNullOrEmpty(textBox.text))
        {
            PlayerPrefs.SetString("name", textBox.text);

        }
        else
        {
            PlayerPrefs.SetString("name", "dummy");
            PlayerPrefs.SetInt("difficulty", 1);
            PlayerPrefs.SetInt("score", 0);
        }
            Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
            PlayerData curPlayer = SaveManager.LoadPlayer(PlayerPrefs.GetString("name"));
            setPlayer(curPlayer);
        
    }
    public void setPlayer(PlayerData player) 
    {
        PlayerPrefs.SetString("name", player.name);
        PlayerPrefs.SetInt("score", player.highscore);
        if (getDifficulty() == 0)
        {
            changeDifficulty(player.difficulty);
        }
    }
    public void setScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
        Debug.Log("Your score is " + PlayerPrefs.GetInt("score"));
    }
    
    public void changeDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
        Debug.Log("Difficulty set to " + PlayerPrefs.GetInt("difficulty"));
    }

    public string getName()
    {
        return PlayerPrefs.GetString("name");
    }
    public int getHighScore()
    {
        return PlayerPrefs.GetInt("score");
    }
    public PlayerData getPlayer()
    {
        Player player = new Player();
        player.userName = getName();
        player.highscore = getHighScore();
        player.difficulty = getDifficulty();
        PlayerData playerData = new PlayerData(player);
        return playerData;
    }

    public int getDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty");
    }

    public void newHighScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
    }

    public void SavePlayer()
    {
        Player playerToSave = new Player();
        playerToSave.userName = getName();
        playerToSave.difficulty = getDifficulty();
        playerToSave.highscore = getHighScore();
        SaveManager.SavePlayer(playerToSave);
    }
}

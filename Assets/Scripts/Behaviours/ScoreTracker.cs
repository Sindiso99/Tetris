using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public Text scoreBox;
    public Text personalBest;
    public Text leaderBoardText;

    public TMP_Text leaderBoardName;
    public TMP_Text leaderBoardScore;

    private int score;
    public GameObject gameOverUI;
    public GameObject inGameUI;
    private SaveGame saveGame;
    private LeaderBoard leaderBoard;

    // Start is called before the first frame update
    void Start()
    {
        saveGame = GetComponent<SaveGame>();
        personalBest.text = saveGame.getHighScore().ToString();
        leaderBoard = SaveManager.LoadLeaderBoard();
        leaderBoardText.text = leaderBoard.highScores[0].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int score)
    {
        this.score += score;
        scoreBox.text = this.score.ToString();
        if (this.score > saveGame.getHighScore())
        {
            saveGame.newHighScore(this.score);
            personalBest.text = saveGame.getHighScore().ToString();
        }
    }



    public void EndGame()
    {
        if (score > saveGame.getHighScore())
        {
            saveGame.newHighScore(score);
        }
        leaderBoard.compareScore(saveGame.getPlayer());
        saveGame.SavePlayer();
        SaveManager.SaveLeaderBoard(leaderBoard);
        DisplayLeaderBoard();
        gameOverUI.SetActive(true);
        inGameUI.SetActive(false);
    }

    public void DisplayLeaderBoard()
    {
        leaderBoardName.text = leaderBoard.NamesToString();
        leaderBoardScore.text = leaderBoard.ScoresToString();
    }
}


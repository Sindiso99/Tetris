using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveManager 
{
    private static string fileName = "/player.tetris";
    public static void SavePlayer (Player player)
    {
        fileName = "/" + player.userName + ".tetris"; 
        BinaryFormatter formatter = new BinaryFormatter();
        string file = Application.persistentDataPath + fileName;
        FileStream fs = new FileStream(file, FileMode.Create);

        PlayerData data = new PlayerData(player);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static PlayerData LoadPlayer(string name)
    {
        fileName = "/" + name + ".tetris";
        string path = Application.persistentDataPath + fileName;
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            PlayerData playerData = bf.Deserialize(fs) as PlayerData;
            fs.Close();
            return playerData;
        }
        else
        {
            Debug.LogError("404: FIle not found " + path);
            Player player = new Player();
            player.userName = name;
            player.highscore = 0;
            player.difficulty = 1;
            PlayerData playerData = new PlayerData(player);
            return playerData;
        }
    }
    public static void SaveLeaderBoard(LeaderBoard leaderBoard)
    {
        fileName = "/top" + LeaderBoard.topMax.ToString() + ".tetris";
        BinaryFormatter formatter = new BinaryFormatter();
        string file = Application.persistentDataPath + fileName;
        FileStream fs = new FileStream(file, FileMode.Create);
        formatter.Serialize(fs, leaderBoard);
        fs.Close();
    }

    public static LeaderBoard LoadLeaderBoard()
    {
        fileName = "/top" + LeaderBoard.topMax.ToString() + ".tetris";
        string path = Application.persistentDataPath + fileName;
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            LeaderBoard leaderBoard = bf.Deserialize(fs) as LeaderBoard;
            fs.Close();
            Debug.Log(leaderBoard.highNames[0]);
            return leaderBoard;
        } else
            {
                Debug.LogError("404: FIle not found " + path);
                LeaderBoard leaderBoard = new LeaderBoard();
                
                return leaderBoard;
            }
        }
    }


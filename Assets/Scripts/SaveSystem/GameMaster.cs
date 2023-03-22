using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    GameData saveData = new GameData();
    


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            saveData.AddScore(-1);
            PrintScore();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            saveData.AddScore(1);
            PrintScore();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            saveData.FillSaveData();
            SaveSystem.instance.SaveGame(saveData);
            Debug.Log("The game has been saved");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            saveData = SaveSystem.instance.LoadGame();
            saveData.FillTempList();
            Debug.Log("New data loaded");
            PrintScore();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            saveData.ResetData();
            PrintScore();
            
        }
    }

    void PrintScore()
    {
        Debug.Log("The current score is " + saveData.score);
    }
}

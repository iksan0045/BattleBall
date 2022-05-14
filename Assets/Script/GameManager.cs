using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BattleField blueField;
    [SerializeField] BattleField redField;
    [SerializeField] RandomSpawnBall blueSpawn;
    [SerializeField] RandomSpawnBall redSpawn;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject labir;
    [SerializeField] GameObject UIMaze;
    [SerializeField] GameObject UITurn;
    [Range(0,140)]float timer;

    bool redAttack;
    [SerializeField] int bluescore;
    [SerializeField] int redscore;
    int round;
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        timer = 140;
        ChangeRole("blue");      
        round = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("0") + "s";
        if (round == 0)
        {
            GameOver();
        }
        scoreText.text = redscore.ToString("0") +" : " + bluescore.ToString("0");
    }
    
    public void BlueWin()
    {
        print("blue win");
        bluescore++;
        ChangeRole("red");
        round =- 1;
    }
    public void RedWin()
    {
        print("red win");
        redscore++;
        ChangeRole("blue");
        round =- 1;
    }
    
    public void ChangeRole(string info)
    {
        
        //blue attacking red defend
        if (info == "blue")
        {
            Debug.Log("change blue");
            blueField.AttckTurn(true);
            redField.AttckTurn(false);
            blueSpawn.SpawnRandom();
        }
        //red attack blue defend
        if (info == "red")
        {
            Debug.Log("change red");
            redField.AttckTurn(true);
            blueField.AttckTurn(false);
            redSpawn.SpawnRandom();
        }
        timer = 140;
    }
    private void GameOver()
    {
        if (bluescore > redscore)
        {
            Debug.Log("Blue win");
        }
        if ( redscore > bluescore)
        {
            Debug.Log("red win");
        }
        PenaltyMode();
    }
    public void PenaltyMode()
    {
        UIMaze.SetActive(true);
        UITurn.SetActive(false);
        labir.SetActive(true);
    }


}

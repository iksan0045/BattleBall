using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleField : MonoBehaviour
{
    public bool attacker;
    [Range(0,6f)]public float energyField;
    public bool blue;
    [SerializeField] private Image energyBar;
    [SerializeField] private TextMeshProUGUI roleTextInf;
    [SerializeField] GameObject spawnBall;
    

    void Start()
    {
        
    }

    private void Update() {
        if (energyField <= 6 || energyField == 6)
        {
            energyField += 0.5f * Time.deltaTime;
        }
        
        energyBar.fillAmount = energyField / 6 ;
        
        if (attacker == true)
        {
            roleTextInf.text = "ATTACKER" ;
        }
        else
        {
            roleTextInf.text = "DEFENDER";
        }
    }
    public void AttckTurn(bool turn)
    {
        Debug.Log("role changed");
        if (turn == true)
        {
            attacker = true;
        }
        else
        {
            attacker = false;
        }
    }
    
    public void UseEnergy(float cost)
    {
        energyField -= cost;
    }
    
}

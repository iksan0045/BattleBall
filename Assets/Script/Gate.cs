using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool blueGate;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<AttackSoldier>().bringBall == true)
        {
            Debug.Log("goal");
            RoundWin();
        }
    }
    // Update is called once per frame
    public void RoundWin()
    {
        FindObjectOfType<Ball>().PassBy();
        var attackers = GameObject.FindGameObjectsWithTag ("Attacker");
        foreach (var attacker in attackers)
        {
            Destroy(attacker);
        }
        var defenders = GameObject.FindGameObjectsWithTag ("Defender");
        foreach (var defender in defenders)
        {
            Destroy(defender);
        }
        if (blueGate == true)
        {
            FindObjectOfType<GameManager>().RedWin();
        }
        else
        {
            FindObjectOfType<GameManager>().BlueWin();
        }
    }
    
    void Update()
    {
        
    }
}

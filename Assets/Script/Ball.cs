using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool ballHold;
    [SerializeField] float passDistance;
    Transform attackerPos;
    Transform follow;
    Collider collide;
    void Start()
    {
        collide = GetComponent<Collider>();
        ballHold = false;
    }

    // Update is called once per frame
    
    
    private void OnCollisionEnter(Collision soldier)
    {
        if (soldier.gameObject.tag == "Attacker")
        {
            follow = soldier.gameObject.GetComponent<Transform>();
            ballHold = true;
            Debug.Log("KOK");
            soldier.gameObject.GetComponent<AttackSoldier>().bringBall = true;
            collide.isTrigger = true;
        } 
    }

    private void Update() {
        if (ballHold == true)
        {
            transform.position = follow.position;
        }
    }

    
    public void PassBy()
    {
        collide.isTrigger = false;
        ballHold = false;
    }
        
    private void OnDrawGizmos() {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position,passDistance);
    }
}

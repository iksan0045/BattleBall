using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSoldier : MonoBehaviour
{
    [SerializeField] private Material[] color;
    [SerializeField] private SkinnedMeshRenderer targetColor;
    Transform redGate;
    Transform blueGate;
    Ball ballScript;
    Transform ballPos;
    public bool holdBall;
    public bool bringBall;
    public bool blue;
    public bool active;
    float activeTime;
    [SerializeField] GameObject highLight;
    void Start()
    {
        ballScript = GameObject.FindObjectOfType<Ball>();
        holdBall = ballScript.ballHold;
        ballPos = GameObject.FindGameObjectWithTag("Ball").transform;
        redGate = GameObject.Find("RedGate").transform;
        blueGate = GameObject.Find("BlueGate").transform;
        SetColor(1);   
        active = true; 
        activeTime = 2.5f; 
    }

    // Update is called once per frame
    
    void Update()
    {
        if (active == true)
        {
            if (holdBall == false)
            {
                ChaseBall();
            }
            else{
                MoveForward();
            }   
            if (bringBall == true)
            {
                HoldBall();
            }
        }
        
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Defender")
        {
            FindObjectOfType<Ball>().PassBy();
        }
    }
    private void PassBall()
    {

    }
    void MoveForward()
    {
        if(blue == true)
        {
            transform.position += Vector3.forward * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.back * Time.deltaTime;
        }
        
    }
    public void ChaseBall()
    {        
        transform.position = Vector3.MoveTowards(transform.position,ballPos.position,1.5f *Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.MoveTowards(transform.position,ballPos.position,1.5f *Time.deltaTime));
    }
    private void Inactive()
    {
        active = false;
        SetColor(0);
        
    }
    public void HoldBall()//
    {  
        highLight.SetActive(true);
        if (blue == true)
        {
            transform.position = Vector3.MoveTowards(transform.position,redGate.position, 1.5f * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.MoveTowards(transform.position,redGate.position, 1.5f * Time.deltaTime));
        }
        else{
            transform.position = Vector3.MoveTowards(transform.position,blueGate.position, 1.5f * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.MoveTowards(transform.position,blueGate.position, 1.5f * Time.deltaTime));
        }
        
    }
    private void SetColor(int index)
    {
        targetColor.material = color[index];
    }

}

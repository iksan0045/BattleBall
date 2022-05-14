using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendSoldier : MonoBehaviour
{
    //detect radius value
    [SerializeField] float distanceDetect;
    //------------------||-----------\\
    //for ball 
    private bool ballStat;
    private Transform ballPos;
    [SerializeField] GameObject tranBack;
    //------------------||-------------------\\

    bool active;
    float activeTime;
    Transform originPos;
    [SerializeField] private Material[] color;
    [SerializeField] SkinnedMeshRenderer targetColor;
    void Start()
    {
        ballPos = GameObject.FindGameObjectWithTag("Ball").transform;
        SetColor(1);
        active = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(active == true)
        {
            DefendMode();
        }
        

    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Attacker")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Tangkap");
            Inactive();
        }
    }

    private void DefendMode()
    {
       
        ballStat = GameObject.FindGameObjectWithTag("Attacker").GetComponent<AttackSoldier>().bringBall;
        if (Vector3.Distance(transform.position,ballPos.position) < distanceDetect)
            {
                if (ballStat == true)
                {
                    transform.position = Vector3.MoveTowards(transform.position,ballPos.position, 1 * Time.deltaTime);
                    transform.rotation = Quaternion.LookRotation(Vector3.MoveTowards(transform.position,ballPos.position, 1 * Time.deltaTime));
                }
                // Debug.Log("dalam Jangkauan");
            }
        
        
    }

    public void Inactive()
    {
        active = false;
        targetColor.material = color[0];
        Destroy(gameObject,1f);
    }
    public void SetColor(int colorIndex)
    {
        targetColor.material = color[colorIndex];
    }
    

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,distanceDetect);
    }
}

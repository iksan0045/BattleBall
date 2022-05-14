using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject[] soldier;
    private float energySpawn;
    [SerializeField] GameObject spawnEffect;
    private bool attacker;
    private bool blueSoldier;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                //checking field status and energy before spawn
                energySpawn = hit.transform.GetComponent<BattleField>().energyField;
                attacker = hit.transform.GetComponent<BattleField>().attacker;
                blueSoldier = hit.transform.GetComponent<BattleField>().blue;
                if (attacker == true)
                {
                    if (blueSoldier)
                    {
                        if (energySpawn >= 2 || energySpawn == 2)
                        {
                            hit.transform.GetComponent<BattleField>().UseEnergy(2);
                            SpawnPion(0);
                        }
                    }
                    else 
                    {
                        if (energySpawn >= 2 || energySpawn == 2)
                        {
                            hit.transform.GetComponent<BattleField>().UseEnergy(2);
                            SpawnPion(1);
                        }
                    }
                    
                }
                else
                {
                    if (blueSoldier)
                    {
                        if (energySpawn >= 3 || energySpawn == 3)
                        {
                            hit.transform.GetComponent<BattleField>().UseEnergy(3);
                            SpawnPion(2);
                        }
                    }
                    else
                    {
                        if (energySpawn >= 3 || energySpawn == 3)
                        {
                            hit.transform.GetComponent<BattleField>().UseEnergy(3);
                            SpawnPion(3);
                        }
                    }
                    
                }
                
            }
        }   
    }
    void SpawnPion(int index)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(spawnEffect,pos,Quaternion.identity);
        Instantiate(soldier[index],pos,Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnBall : MonoBehaviour
{
    [SerializeField] private GameObject ballGameObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnRandom()
    {
        Debug.Log("Spawn");
        Vector3 origin = transform.position;
        Vector3 range = transform.localScale / 2.0f;
        Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),Random.Range(-range.y, range.y),Random.Range(-range.z, range.z));
        Vector3 randomCoordinate = origin + randomRange;
        ballGameObject.transform.position = randomCoordinate;
    }
    private void OnDrawGizmos() {
        Gizmos.color = new Color(1f,1f,1f,1f);
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}

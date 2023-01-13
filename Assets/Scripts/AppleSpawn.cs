using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawn : MonoBehaviour
{
    public static AppleSpawn instance;
    public GameObject prefabApple;

    public float boundsX = 10f, boundsZ = 10f;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        respawnApple();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void respawnApple() {
        float randomX = Random.Range(-boundsX/2, boundsX/2);
        float randomZ = Random.Range(-boundsZ/2, boundsZ/2);
        Vector3 newRandomPoint = new Vector3(randomX, transform.position.y, randomZ);
        Instantiate(prefabApple, newRandomPoint, Quaternion.identity); 
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(boundsX, 0.2f, boundsZ));
    }

}

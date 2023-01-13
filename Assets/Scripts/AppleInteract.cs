using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleInteract : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            AppleSpawn.instance.respawnApple();
            other.GetComponent<SnakeMovement>().addBodyPart();
            GameManager.instance.AddPoints();
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] float Speed = 5f;
    [SerializeField] float rotationSpeed = 100f;
    Vector3 currentMovement = Vector3.forward;
    List<GameObject> snakeBody;
    public GameObject bodyPrefab;

    public float minDistance = 5f;

    public float speedMultiplier = 1.15f; 

    public float maxSpeed = 9f;

    public float maxRotation = 180f;
    private float dis;

    private float setUpCoroutineTimer = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(setUpSnake());
    }

    IEnumerator setUpSnake() {
        snakeBody = new List<GameObject>();
        snakeBody.Add(this.gameObject);
        addBodyPart();
        addBodyPart();
        snakeBody[1].tag = "Player";
        snakeBody[2].tag = "Player";
        yield return new WaitForSeconds(setUpCoroutineTimer);
        snakeBody[2].tag = "Obstacle";
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
        //transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        if(Input.GetAxis("Horizontal") != 0) {
            transform.Rotate(Vector3.up * rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }
        bodyPartsMovement();
    }

    public void bodyPartsMovement() {
        for (int i = 1; i < snakeBody.Count; i++)
        {
            dis = Vector3.Distance(snakeBody[i - 1].transform.position, snakeBody[i].transform.position);
            Vector3 newpos = snakeBody[i - 1].transform.position;
            newpos.y = snakeBody[0].transform.position.y;
            float T = Time.deltaTime * dis / minDistance * Speed;
            snakeBody[i].transform.position = Vector3.Lerp(snakeBody[i].transform.position, newpos, T);
        }
    }
    public void addBodyPart() {
        GameObject bodyPart = Instantiate(bodyPrefab, transform.parent);
        bodyPart.transform.position = snakeBody[snakeBody.Count - 1].transform.position;
        snakeBody.Add(bodyPart);
        if((snakeBody.Count - 3) % 5 == 0 && snakeBody.Count > 3) {
            Speed *= speedMultiplier;
            rotationSpeed *= speedMultiplier;
            if(Speed > maxSpeed) {
                Speed = maxSpeed;
                rotationSpeed = maxRotation;
            }
            else {
                GameManager.instance.PointsMultiplier += 5;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Obstacle") {
            GameManager.instance.GameOver();
        }
    }
}

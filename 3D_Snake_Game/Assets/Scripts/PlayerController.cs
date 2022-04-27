using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public SpawnManager spawnManager;
    public ScoreManager scoreManager;
    

    public GameObject bodyPrefab;
    public GameObject gameOverUI;
    public GameObject gameManager;

    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionsHistory = new List<Vector3>();


    public float moveSpeed = 2000f;
    public float speed = 2000f;
    public int gap = 5;

    public bool isAlive = true;
    public bool foodTaken = false;

    
    void FixedUpdate()
    {
        if (isAlive)
        {
            //move forward
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            //rotate
            if (Input.touchCount > 0)
            {
                if (Input.touchCount == 1)
                {
                    Touch screenTouch = Input.GetTouch(0);
                    float steerDirection = screenTouch.deltaPosition.x;

                    if (screenTouch.phase == TouchPhase.Moved)
                    {
                        transform.Rotate(Vector3.up * steerDirection * speed * Time.deltaTime);
                    }
                }
            }

            // store position 
            positionsHistory.Insert(0, transform.position);

            // move body
            int index = 0;
            foreach (var body in bodyParts)
            {
                Vector3 point = positionsHistory[Mathf.Min(index * gap, positionsHistory.Count - 1)];
                Vector3 moveDirection = point - body.transform.position;
                body.transform.position += moveDirection * moveSpeed * Time.deltaTime;
                body.transform.LookAt(point);
                index++;
            }
        }
        
        

    }

    private void GrowSnake()
    {
        GameObject body = Instantiate(bodyPrefab);
        bodyParts.Add(body);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            foodTaken = true;
            other.gameObject.SetActive(false);
            ScoreManager.instance.AddPoint();
            GrowSnake();
            StartCoroutine(FoodCooldown());
            spawnManager.SpawnFood();
        }

        if(other.tag == "Obstacle")
        {
            isAlive = false;
            gameOverUI.SetActive(true);
            

        }

        if (other.tag == "Walls")
        {
            isAlive = false;
            gameOverUI.SetActive(true);
            

        }



    }

    // Cooldown
    IEnumerator FoodCooldown()
    {
        yield return new WaitForSeconds(5);

    }


}

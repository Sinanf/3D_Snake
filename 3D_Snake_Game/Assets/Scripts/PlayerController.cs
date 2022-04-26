using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpawnManager spawnManager;

    public GameObject bodyPrefab;

    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionsHistory = new List<Vector3>();


    public float moveSpeed = 5f;
    public float speed = 15;
    public int gap = 5;

    public bool foodTaken = false;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void FixedUpdate()
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
            Vector3 point = positionsHistory[Mathf.Min(index * gap, positionsHistory.Count -1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * moveSpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
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
            Debug.Log("You collected piece");
            GrowSnake();
            StartCoroutine(FoodCooldown());
            spawnManager.SpawnFood();
        }

        if(other.tag == "Obstacle")
        {
            //Game Over

        }

        if (other.tag == "Walls")
        {
            //Game Over

        }



    }

    // Cooldown
    IEnumerator FoodCooldown()
    {
        yield return new WaitForSeconds(5);


    }


}

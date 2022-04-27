using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private int speed = 50;
    
    void Update()
    {
        transform.Rotate(Vector3.one * speed * Time.deltaTime);
    }
}

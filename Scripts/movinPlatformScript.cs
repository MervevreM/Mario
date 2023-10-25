using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movinPlatformScript : MonoBehaviour
{
    public GameObject[] Point;
    public int currentPointIndex = 0;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,Point[currentPointIndex].transform.position) < 1f)
        {
            currentPointIndex++;
            if(currentPointIndex >= Point.Length)
            {
                currentPointIndex = 0;
            }

        }

        transform.position = Vector3.MoveTowards(transform.position, Point[currentPointIndex].transform.position, speed * Time.deltaTime);
    }
}

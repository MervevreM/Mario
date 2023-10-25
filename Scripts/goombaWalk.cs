using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goombaWalk : MonoBehaviour
{
    public GameObject[] Point;
    public int currentPointIndex = 0;
    public float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
          //  transform.position = new Vector3(transform.position.x, .6f, transform.position.z);
            if (Vector3.Distance(transform.position, Point[currentPointIndex].transform.position) < 0.4f)
            {
                currentPointIndex++;
                if (currentPointIndex >= Point.Length)
                {
                    currentPointIndex = 0;
                }
                if (currentPointIndex %2 == 1)
                {
                    transform.eulerAngles = new Vector3(-90, 270, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(-90, 90, 0);
                }

            }

            transform.position = Vector3.MoveTowards(transform.position, Point[currentPointIndex].transform.position,  speed*Time.deltaTime);
        }
    }
}

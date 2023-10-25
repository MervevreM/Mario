using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goombaCollisionScript : MonoBehaviour
{
    public GameObject GM;
    public gameManager GMS;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("gameManager");
        GMS = GM.GetComponent<gameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }




}






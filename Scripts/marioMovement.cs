using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class marioMovement : MonoBehaviour
{
    public AudioSource SFXSource;

    public AudioClip squishSound;

    

    public GameObject GM;
    public gameManager GMS;
    public GameObject MarioObject;
    public Animator MarioAnimator;
    public Animator goombaAnimator;
    public Collider goombaCollider;
    
   

    public bool IsGround;
    public float marioSpeed = 5f;
    public float jumpForce = 5.5f;
    
    // Start is called before the first frame update
    void Start()
    {
       
        GM = GameObject.Find("gameManager");
        GMS = GM.GetComponent<gameManager>();
        MarioObject = GameObject.Find("MarioWithAnim");
        MarioAnimator = MarioObject.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (GMS.isStartedBool)
        {
            float horizontalValue = Input.GetAxis("Horizontal");
            float verticalValue = Input.GetAxis("Vertical");
            transform.Translate(horizontalValue * marioSpeed * Time.deltaTime, 0f, verticalValue * marioSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space) && IsGround)
            {
                IsGround = false;
                transform.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpForce, 0);
                MarioAnimator.SetBool("willJump", true);
            }
            else
            {
                MarioAnimator.SetBool("willJump", false);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                MarioAnimator.SetBool("willRun", true);

            }
            else
            {
                MarioAnimator.SetBool("willRun", false);
            }
        }



    }


    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "ground" || collision.gameObject.tag == "brick")
        {
            IsGround = true;
        }

        if (collision.gameObject.tag == "cactus")
        {
            GMS.damage(.5f);
        }
        if (collision.gameObject.tag == "goomba" && gameObject.transform.position.y >= 22.7f) //
        {
            goombaAnimator = collision.gameObject.GetComponent<Animator>();
            goombaCollider = collision.gameObject.GetComponent<BoxCollider>();
            SFXSource.PlayOneShot(squishSound);
            goombaAnimator.SetBool("willSquish", true);
            goombaCollider.enabled = false;
           
            
            
            
            Destroy(collision.gameObject, 1);
            
            // StartCoroutine(goombaSquishWaiter());



            //  Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag =="goomba" && gameObject.transform.position.y < 22.7f)
        {
            GMS.damage(1f);
        }

    }

    


    IEnumerator moreCoinTxtWaiter()
    {
        yield return new WaitForSecondsRealtime(1f);
        
        
        
    }
}

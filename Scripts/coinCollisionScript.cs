using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollisionScript : MonoBehaviour
{
    public GameObject GM;
    public gameManager GMS;

    public GameObject SFXSourceObj;
    public AudioSource SFXSource;
    public AudioClip coinCollectSound;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("gameManager");
        GMS = GM.GetComponent<gameManager>();

        SFXSourceObj = GameObject.Find("SoundManager/SFX");
        SFXSource = SFXSourceObj.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mario")
        {
            GMS.addScore(5);
            SFXSource.PlayOneShot(coinCollectSound);
            coinWait();
            // transform.localScale = new Vector3(0, 0, .1f);
            Destroy(gameObject);
        }


    }

    public IEnumerator coinWait()
    {
        yield return new WaitForSecondsRealtime(1f);
    }


}

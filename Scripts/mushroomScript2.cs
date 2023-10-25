using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mushroomScript2 : MonoBehaviour
{
    public GameObject GM;
    public gameManager GMS;
    public AudioSource SFXAudioSource;
    public AudioClip PickUpHealthSound;

    public GameObject healtImgObj;
    public Image healthImgFill;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("gameManager");
        GMS = GM.GetComponent<gameManager>();

        healtImgObj = GameObject.Find("Canvas/healthImg");
        healthImgFill = healtImgObj.GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mario")
        {
            SFXAudioSource.PlayOneShot(PickUpHealthSound);
            GMS.health++;
            healthImgFill.fillAmount = GMS.health / 5f;
            Destroy(gameObject);

        }
    }
}

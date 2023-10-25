using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickBreakScript : MonoBehaviour
{
    public ParticleSystem brickBreakEffect;
    public GameObject SFXSourceObj;
    public AudioSource SFXSource;
    public AudioClip BrickBreakSound;

    // Start is called before the first frame update
    void Start()
    {
        brickBreakEffect.Stop();
        SFXSourceObj = GameObject.Find("SoundManager/SFX");
        SFXSource = SFXSourceObj.GetComponent<AudioSource>();
        
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if ( (gameObject.transform.position.y - collision.transform.position.y) > 2f)
        {
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            SFXSource.PlayOneShot(BrickBreakSound);
            gameObject.transform.localScale = new Vector3(0f, 0f, 0.1f);
            StartCoroutine(breakWait());
        }


    }

    IEnumerator breakWait()
    {
        
        yield return new WaitForSecondsRealtime(1f);
        Destroy(gameObject);
    }
}

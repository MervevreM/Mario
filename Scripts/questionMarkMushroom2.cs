using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionMarkMushroom2 : MonoBehaviour
{
    public GameObject mushroomObj;
    public Animator mushroomAnimator;
    public AnimationClip mushroomestroyAnimClip;

    // Start is called before the first frame update
    void Start()
    {
        mushroomObj = GameObject.Find("mushroom2");
        mushroomAnimator = mushroomObj.GetComponent<Animator>();

        mushroomObj.GetComponent<Rigidbody>().isKinematic = true;
        mushroomAnimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mario")
        {
            mushroomObj.GetComponent<Rigidbody>().isKinematic = false;
            mushroomObj.GetComponent<Rigidbody>().velocity = new Vector3(0, 8f, -5f);
            StartCoroutine(waitFunc(3f));
        }





    }

    IEnumerator waitFunc(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        mushroomAnimator.enabled = true;
        yield return new WaitForSecondsRealtime(time - 2);
        Destroy(mushroomObj);

    }
}

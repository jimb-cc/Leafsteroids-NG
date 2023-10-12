using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// LERP -> https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/#lerp_rotation

public class DocRot : MonoBehaviour
{
    public int RotateSpeed;
    public ParticleSystem sparkle;
    private Vector3 scaleChange;
    public int beingCollected=0;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, UnityEngine.Random.Range(0,359), 0);
                
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);

        if (beingCollected==1)
        {
            scaleChange = new Vector3(0.02f, 0.02f, 0.02f);
            transform.localScale -= scaleChange;

            if (transform.localScale.x < 0.01f)
            {
                //Debug.Log("Destroy object: " + gameObject.name + "at localScale: "+ transform.localScale.x); 
                Destroy(gameObject);
            }
        }


    }

    public void Sparkle()
    {
        sparkle.Play();
        beingCollected = 1;
    }
    public void BadSparkle()
    {
        sparkle.startColor = Color.red;
        sparkle.Play();
        beingCollected = 1;
    }

    public void PUSparkle()
    {
        //sparkle.Play();
        beingCollected = 1;
    }

}

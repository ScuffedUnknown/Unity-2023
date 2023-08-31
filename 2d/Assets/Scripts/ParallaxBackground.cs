using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    float startPos;
    float lengthOfSprite;
    public float parallaxAmount;
    public GameObject cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float tempPosX = (cameraPos.transform.position.x * (1 - parallaxAmount));
        float dist = (cameraPos.transform.position.x * parallaxAmount);

        //update background position
        transform.position = new Vector3(startPos+dist, transform.position.y, transform.position.z);

        if (tempPosX > startPos + lengthOfSprite)
        {
            startPos += lengthOfSprite;
        }
        else if (tempPosX < startPos - lengthOfSprite)
        {
            startPos -= lengthOfSprite;
        }
    }
}

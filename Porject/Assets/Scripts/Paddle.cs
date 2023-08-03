using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float smooth = 5.0f;
    float tiltAngle = 60.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Getting mouse input for paddle pos.

        Vector3 pos = new Vector3((Input.mousePosition.x - Screen.width / 2)/(Screen.width/10), transform.position.y, (Input.mousePosition.y - Screen.height / 2) / (Screen.height / 10));

        //getting input for paddle rotation
        float tiltAroundZ = Input.GetAxis("Mouse X") * tiltAngle;    
        float tiltAroundX = Input.GetAxis("Mouse Y") * tiltAngle* -1;
        Quaternion targetRotation = Quaternion.Euler(tiltAroundX, 0,tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation, Time.deltaTime * smooth);

        transform.position = pos;
    }
}

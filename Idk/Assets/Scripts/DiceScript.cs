using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    public Transform throwPos;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       //transform.rotation = Random.rotation;
        throwPos = GameObject.Find("ThrowPlace").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        transform.position = throwPos.position;
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(Random.Range(-3,-6),2,0), ForceMode.Impulse);
    }
}

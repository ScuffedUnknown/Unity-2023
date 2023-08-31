using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    public Transform thrownPos;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Random.rotation;
        thrownPos = GameObject.Find("ThrowPosition").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        transform.position = thrownPos.position;
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(Random.Range(-5,-8), 2, 0), ForceMode.Impulse);

    }
 
}

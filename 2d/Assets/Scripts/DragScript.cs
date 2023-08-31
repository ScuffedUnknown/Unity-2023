using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        GetComponent<Collider2D>().enabled = false;

        transform.position = objPosition;
    }

    private void OnMouseUp()
    {
        GetComponent<Collider2D>().enabled = true;
        rb2d.velocity = Vector2.zero;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector3 direction;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);

        Time.timeScale = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
            //transform.Translate(Vector3.up);

            direction = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
            //transform.Translate(0, -1, 0);

            direction = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            //transform.Translate(-1, 0, 0);

            direction = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");
            //transform.Translate(1, 0, 0);

            direction = Vector3.right;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(direction);
    }
}

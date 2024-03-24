using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector3 direction;
    public float speed;

    public Transform bodyPrefab;

    public List<Transform> bodies = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.position);

        Time.timeScale = speed;

        ResetStage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
           // Debug.Log("W");
            //transform.Translate(Vector3.up);

            direction = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Debug.Log("S");
            //transform.Translate(0, -1, 0);

            direction = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("A");
            //transform.Translate(-1, 0, 0);

            direction = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("D");
            //transform.Translate(1, 0, 0);

            direction = Vector3.right;
        }
    }

    private void FixedUpdate()
    {
        for(int i = bodies.Count - 1; i > 0; i--)
        {
            bodies[i].position = bodies[i - 1].position;
        }

        transform.Translate(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            //Instantiate(bodyPrefab);

            bodies.Add(Instantiate(bodyPrefab));
        }
        //Debug.Log(collision);        

        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("game over");

            ResetStage();
        }
    }

    void ResetStage()
    {
        transform.position = Vector3.zero;
        direction = Vector3.zero;

        for (int i = 1; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);
        }
        bodies.Clear();
        bodies.Add(transform);
    }
}

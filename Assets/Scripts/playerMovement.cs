using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject player;
    Transform playerPosition;
    Rigidbody2D playerBody;
    BoxCollider2D playerCollider;
    Vector2 move = new Vector2(0, 0);
    float speed = 100f;
    static List<Collider2D> woodList = new List<Collider2D>();
    bool on = false;


    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.GetComponent<Transform>();
        playerBody = player.GetComponent<Rigidbody2D>();
        playerCollider = player.GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (woodList.Count != 0)
        {
            for (int x = 0; x < woodList.Count; x++)
            {
                Physics2D.IgnoreCollision(playerCollider, woodList[x]);
            }
        }
        

        Vector2 move = new Vector2(0, 0);
        playerBody.velocity = move;
        /*
        if (Input.GetKey("up"))
        {
            //playerPosition.Translate(Vector2.up * Time.deltaTime * speed);
        }
        if (Input.GetKey("down"))
        {
            //playerPosition.Translate(Vector2.down * Time.deltaTime * speed);
        }
        if (Input.GetKey("left"))
        {
            //playerPosition.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if (Input.GetKey("right"))
        {
            //playerPosition.Translate(Vector2.right * Time.deltaTime * speed);
        }
        */

        if (Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("up") || Input.GetKey("down"))
        {
            move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            move.Normalize();
            move *= speed;
            playerBody.AddForce(move * speed);
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (woodList.Count != 0)
            {
                Collider2D currentWood = woodList[0];
                if (currentWood != null && on == false)
                {
                    if (currentWood.gameObject.layer == 8)
                    {
                        woodList.RemoveAt(0);
                        Destroy(currentWood.gameObject);
                        dataTracker.addSmallWood();
                    }
                    else if (currentWood.gameObject.layer == 9)
                    {
                        woodList.RemoveAt(0);
                        Destroy(currentWood.gameObject);
                        dataTracker.addBigWood();

                    }
                    on = true;
                }
            }


        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            on = false;
        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (woodList.Contains(col) == false)
        {
            woodList.Add(col);
            Debug.Log(woodList.Count);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        woodList.Remove(col);
        Debug.Log(woodList.Count);

    }

}

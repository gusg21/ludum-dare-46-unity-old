using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraNewPosition = new Vector3(playerPosition.position.x, playerPosition.position.y, -1);
        transform.position = cameraNewPosition;
    }
}

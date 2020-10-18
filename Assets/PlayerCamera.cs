using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Camera follows the player with specified offset position
        transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, offset.z);
    }
}

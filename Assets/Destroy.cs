using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    private GameObject myPlat;
    public Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, player.transform.position.z);
        // box.offset = new Vector2(player.transform.position.x + offset.x, player.transform.position.y + offset.y);
    }

    private void move(Collider2D collision)
    {
        collision.gameObject.transform.position = new Vector2(Random.Range(-6f, 6f), player.transform.position.y + (14 + Random.Range(0.5f, 1f)));
    }

    private void replace(Collider2D collision, GameObject prefab)
    {
        Destroy(collision.gameObject);
        Instantiate(prefab, new Vector2(Random.Range(-6f, 6f), player.transform.position.y + (14 + Random.Range(0.5f, 1f))), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.StartsWith("Platform"))
        {
            if (Random.Range(1, 7) == 1)
            {
                replace(collision, springPrefab);
            }
            else
            {
                move(collision);
            }
        }
        else if (collision.gameObject.name.StartsWith("Spring"))
        {
            if (Random.Range(1, 7) == 1)
            {
                move(collision);
            }
            else
            {
                replace(collision, platformPrefab);
            }
        }
    }
}

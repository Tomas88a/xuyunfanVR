using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    GameObject player;
    public float range = 10f;
    bool hasShot = false;
    public GameObject bullet;

    void Start()
    {
        player = GameObject.Find("XR Origin");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceToPlayer < range)
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            if (Physics.Raycast(transform.position, directionToPlayer, out RaycastHit hit, distanceToPlayer - 2))
            {
                if (hit.collider.gameObject.CompareTag("Wall"))
                {
                    return;
                }
            }
            else
            {
                transform.LookAt(player.transform);
                if(!hasShot)
                {
                    hasShot = true;
                    StartCoroutine("Shoot");
                }
            }
        }
    }


    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(bullet, transform.position, transform.rotation);
        hasShot = false;
    }
}

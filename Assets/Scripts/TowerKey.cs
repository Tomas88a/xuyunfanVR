using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerKey : MonoBehaviour
{
    public GameObject towerDesVfx;
    public GameObject tower;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(towerDesVfx, tower.transform.position, Quaternion.identity);
            
            Destroy(tower);
        }
    }
}

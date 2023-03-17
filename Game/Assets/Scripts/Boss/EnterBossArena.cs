using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBossArena : MonoBehaviour
{
    public GameObject HealthBarWrapper;

    public GameObject Wall;
    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("enter");
        if (other.gameObject.GetComponent<PlayerHealth>() != null)
        {
            StartBossFight();
        }
    }
    private void StartBossFight() {
        HealthBarWrapper.SetActive(true);
        Wall.SetActive(true);
    }
}
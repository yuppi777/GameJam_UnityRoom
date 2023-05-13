using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PlayerSarch : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーが索敵範囲に入ったかどうか")]
    private bool playerOn;

    public bool PlayerOn { get => playerOn;  }

    private void Start()
    {
        playerOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOn = true;
            //Debug.Log("Pばれた");
        }
        //Debug.Log("呼ばれた");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //playerOn = false;
           
        }
    }

}

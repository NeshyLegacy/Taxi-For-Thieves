using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criminal_CS : MonoBehaviour
{
    Rigidbody rb;
    GameObject dropOffPoint;

    void Start()
    {
        dropOffPoint = LevelManager_CS.instance.GetRandomDropOff();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Criminal Picked up!");
            LevelManager_CS.instance.playerhasCrim = true;
            GameUI_CS.instance.haveCrim = true;
            GameUI_CS.instance.UpdateUI();
            gameObject.transform.position = new Vector3(0, -25, 0);
            dropOffPoint.SendMessage("Activate");
        }
    }
}
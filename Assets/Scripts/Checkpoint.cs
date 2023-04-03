using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public PlayerController PlayerController;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController.respawnpoint = this.transform.position;
    }
}

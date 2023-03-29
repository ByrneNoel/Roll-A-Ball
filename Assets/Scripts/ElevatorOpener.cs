using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpener : MonoBehaviour
{
    public GameObject _blockingWall;
    public GameObject _elevator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            _blockingWall.SetActive(false);
            _elevator.SetActive(true);
        }
    }
}

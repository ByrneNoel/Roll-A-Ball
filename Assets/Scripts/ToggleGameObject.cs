using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject _target;
    public bool state;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
           _target.SetActive(state);
            
        }
    }
}

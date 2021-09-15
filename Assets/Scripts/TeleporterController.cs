using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextDoor;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = nextDoor.transform.position;
        other.transform.rotation = nextDoor.transform.rotation;
    }

}

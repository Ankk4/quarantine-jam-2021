using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPart : MonoBehaviour
{


    public void OnTriggerEnter(Collider other)
    {
        RunPartManager.Instance.SpawnRunPart();
    }

}

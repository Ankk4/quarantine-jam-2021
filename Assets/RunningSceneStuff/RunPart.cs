using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPart : MonoBehaviour
{


    public void OnTriggerEnter(Collider other)
    {
        print("ontrigger eneter");
        RunPartManager.Instance.SpawnRunPart();
    }

}

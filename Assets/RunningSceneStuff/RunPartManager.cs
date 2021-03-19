using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPartManager : MonoBehaviour
{
    private static RunPartManager _instance;
    public static RunPartManager Instance { get { return _instance; } }

    [SerializeField] private GameObject runPartPrefab;

    public List<RunPart> runParts = new List<RunPart>();



    private void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        var initialRunParts = FindObjectsOfType<RunPart>();
        foreach(RunPart part in initialRunParts) {
            runParts.Add(part);
        }

    }

    public void SpawnRunPart() {
        Vector3 newSpawnPos = runParts[runParts.Count-1].transform.position + new Vector3(0,0,50);
        GameObject newPart = Instantiate(runPartPrefab, newSpawnPos, Quaternion.identity);
        runParts.Add(newPart.GetComponent<RunPart>());
    }



}

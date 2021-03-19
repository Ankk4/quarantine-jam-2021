using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private float yOffset, zOffset;
    [SerializeField]
    private GameObject[] targets;

    private int currentTarget;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, yOffset, zOffset);
    }

    void LateUpdate ()
    {
        transform.position = targets[currentTarget].transform.position + offset;
    }

    public void SetPlayerTarget()
    {
        currentTarget = 0;
    }

    public void SetGhostTarget()
    {
        currentTarget = 1;
    }
}


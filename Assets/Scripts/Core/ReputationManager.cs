using UnityEngine;

public class ReputationManager : MonoBehaviour
{
    public int currentReputation = 50;

    private void Update()
    {
        Mathf.Clamp(currentReputation, 0, 100);
    }
}

using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameManager GameManager;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.FinishGame();
    }
}

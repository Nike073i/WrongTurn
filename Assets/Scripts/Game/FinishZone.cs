using UnityEngine;
using Zenject;

public class FinishZone : MonoBehaviour
{
    private RaceManager _raceManager;

    [Inject]
    private void Construct(RaceManager raceManager)
    {
        _raceManager = raceManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        _raceManager.FinishGame();
    }
}

using UnityEngine;
using UnityEngine.Events;

public class FinishLevel : MonoBehaviour
{
    private bool _isFinished = false;

    public bool IsFinished => _isFinished;
    public UnityAction<Multiplier> Finished;

    private void OnEnable()
    {
        Finished += OnLevelFinished;
    }

    private void OnDisable()
    {
        Finished -= OnLevelFinished;
    }

    public void WasFinished()
    {
        _isFinished = true;
    }

    public void OnLevelFinished(Multiplier multiplier)
    {
        PlayerCollector collector = FindObjectOfType<PlayerCollector>();
        int catchedCatCount = collector.PlayerCollectedItemsCount;
        int collectedMoney = collector.CollectedMoney;
        
        PlayerMove.Instance.StopMovement();
        multiplier.CalculateMultiplier(catchedCatCount);
        
        PlayerMultiplyMover.Instance.MultiplierCoroutine(multiplier.CurrentMultiplier, multiplier, collectedMoney);
        WasFinished();
    }
}
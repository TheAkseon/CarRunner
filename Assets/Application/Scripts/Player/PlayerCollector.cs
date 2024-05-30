using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private int _playerCollectedItemsCount;
    private int _collectedMoney;

    public int PlayerCollectedItemsCount => _playerCollectedItemsCount;
    public int CollectedMoney => _collectedMoney;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out CollectedItem collectedItem))
        {
            if (collectedItem.IsCollected == false)
            {
                collectedItem.Collected?.Invoke(collectedItem);
                _playerCollectedItemsCount++;
                _collectedMoney += collectedItem.Cost;
            }
        }
        if (collision.gameObject.TryGetComponent(out FinishLevel finishLevel))
        {
            if (finishLevel.IsFinished == false)
            {
                Multiplier multiplier = FindObjectOfType<Multiplier>();
                
                finishLevel.Finished?.Invoke(multiplier);
            }
        }
    }
}
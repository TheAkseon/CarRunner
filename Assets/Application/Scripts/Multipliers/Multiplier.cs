using UnityEngine;

public class Multiplier : MonoBehaviour
{
    private int _multipliedMoney;
    private float _catCountToMultiply;
    private float _multiplier;

    public float CurrentMultiplier => _multiplier;
    
    private void Start()
    {
        FindCatsToMultiply();
    }

    private void FindCatsToMultiply()
    {
        CatCollector catCollector = FindObjectOfType<CatCollector>();
        _catCountToMultiply = catCollector.CatCount;
    }

    public void CalculateMultiplier(float catchedCatCount)
    {
        _multiplier = (catchedCatCount / _catCountToMultiply) * 100;
        Debug.Log(_multiplier + " Посчитанный множитель, " + Mathf.Ceil(_multiplier) + " Используемый множитель");
        
    }

    public void MultiplyMoney(int collectedMoney)
    {
        _multipliedMoney = collectedMoney * (Mathf.CeilToInt(_multiplier / 10));
        CoinManager.Instance.AddMoney(_multipliedMoney);
    }
}
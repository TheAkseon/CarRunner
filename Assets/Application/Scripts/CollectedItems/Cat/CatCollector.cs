using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CatCollector : MonoBehaviour
{
    private int _catCount;
    private List<CollectedItem> _collectedItems;

    private CatCoutchBar _catCoutchBar;

    public int CatCount => _catCount;

    private void Awake()
    {
        FindCollectedCount();
    }

    private void OnDisable()
    {
        foreach (CollectedItem collectedItem in _collectedItems)
        {
            collectedItem.Collected -= OnCatCollected;
        }
    }

    private void OnCatCollected(CollectedItem collectedItem)
    {
        CoinManager.Instance.AddMoney(collectedItem.Cost);

        if (collectedItem.IsCat == true)
        {
            SoundsManager.Instance.PlaySound("CatchCat");
        }
        else
        {
            SoundsManager.Instance.PlaySound("CatchBox");
        }

        Instantiate(collectedItem.CollectEffectPrefab, collectedItem.ParticlePosition.position, Quaternion.identity);
        _collectedItems.Remove(collectedItem);
        collectedItem.WasCollected();
        collectedItem.Collected -= OnCatCollected;
        Destroy(collectedItem.gameObject);

        if(_catCoutchBar == null)
        {
            _catCoutchBar = FindObjectOfType<CatCoutchBar>();
            Debug.Log("Получил бар");
        }

        _catCoutchBar.fillBar();
    }

    private void FindCollectedCount()
    {
        _collectedItems = FindObjectsOfType<CollectedItem>().ToList();
        _catCount = _collectedItems.Count;
        Debug.Log("Посчитал количество котов: " + _catCount);

        foreach (CollectedItem collectedItem in _collectedItems)
        {
            collectedItem.Collected += OnCatCollected;
        }
    }
}
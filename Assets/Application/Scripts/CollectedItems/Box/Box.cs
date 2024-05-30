using TMPro;
using UnityEngine;

public class Box : CollectedItem
{
    [SerializeField] private TextMeshProUGUI _boxCostText;

    private void Start()
    {
        SetIsBoxValue();
    }

    public void SetCost(int value)
    {
        _cost = value;
        //_boxCostText.text = value.ToString(); надо добавить кол-во котов, которые будут в коробке на канвас
    }

    private void SetIsBoxValue()
    {
        _isCat = false;
    }
}
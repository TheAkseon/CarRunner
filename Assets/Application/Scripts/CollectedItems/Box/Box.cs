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
        //_boxCostText.text = value.ToString(); ���� �������� ���-�� �����, ������� ����� � ������� �� ������
    }

    private void SetIsBoxValue()
    {
        _isCat = false;
    }
}
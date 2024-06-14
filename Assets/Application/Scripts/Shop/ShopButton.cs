using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private GameObject _notBuy;
    [SerializeField] private GameObject _isBuyBox;
    [SerializeField] private GameObject _isApplied;
    [SerializeField] private TextMeshProUGUI _priceText;

    public GameObject NotBuy => _notBuy;
    public GameObject IsBuyBox => _isBuyBox;
    public GameObject IsApplied => _isApplied;
    public TextMeshProUGUI PriceText => _priceText;
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Plugins.Audio.Core;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Shop_grid : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbarVertical;

    public List<ShopButton> _grids;

    public List<GameObject> _notBuy;
    public List<GameObject> _isBuyBox;
    public List<GameObject> _isApplied;

    public List<TextMeshProUGUI> _priceTextes;
    [Header("Prices")]
    [SerializeField] private List<int> _prices;

    public PlayerViev _playerView;
    public bool _isFirstLoad = true;

    public void Back()
    {
        SoundsManager.Instance.PlaySound("Click");
        SoundsManager.Instance.StopSound();
        SoundsManager.Instance.PlayBackGround("1");
    }

    public void LoadShop()
    {
        if (_isFirstLoad)
        {
            foreach (ShopButton _grid in _grids)
            {
                _grid.gameObject.GetComponent<Button>().onClick.AddListener(() => Grid(index: _grids.IndexOf(_grid)));
            }

            _playerView = FindObjectOfType<PlayerViev>(true);

            foreach (ShopButton shopButton in _grids)
            {
                _notBuy.Add(shopButton.NotBuy);
            }

            foreach (ShopButton shopButton in _grids)
            {
                _isBuyBox.Add(shopButton.IsBuyBox);
            }

            foreach (ShopButton shopButton in _grids)
            {
                _isApplied.Add(shopButton.IsApplied);
            }

            foreach (ShopButton shopButton in _grids)
            {
                _priceTextes.Add(shopButton.PriceText);
            }

            for (int _index = 0; _index < (_priceTextes.Count); _index++)
            {
                _priceTextes[_index].text = _prices[_index].ToString();
            }

            _isFirstLoad = false;
        }

        _scrollbarVertical.value = 1;
        SoundsManager.Instance.StopSound();
        SoundsManager.Instance.PlaySound("OpenShop");
        SoundsManager.Instance.PlayBackGround("InShop");

        _isApplied[SaveData.Instance.Data.AppliedSkinIndex].SetActive(true);

        UIBehaviour.Instance.UpdateCoins(SaveData.Instance.Data.Coins);
        CheckIsBuy();
    }

    public void CheckIsBuy()
    {
        int index = 0;
        foreach (GameObject _isbuy in _notBuy)
        {
            if (SaveData.Instance.Data.IsBuyShop[index])
            {
                _notBuy[index].SetActive(false);
                _isBuyBox[index].SetActive(true);
            }
            index++;
        }
    }

    public void Grid(int index)
    {

        Debug.Log($"Нажата {index}");

        if (!SaveData.Instance.Data.IsBuyShop[index])
        {
            if (SaveData.Instance.Data.Coins > _prices[index])
            {
                SoundsManager.Instance.PlaySound("Buy");

                SaveData.Instance.Data.Coins = SaveData.Instance.Data.Coins - _prices[index];
                SaveData.Instance.Data.IsBuyShop[index] = true;
                SaveData.Instance.SaveYandex();

                UIBehaviour.Instance.UpdateCoins(SaveData.Instance.Data.Coins);

                CheckIsBuy();
                //Выдача предмета
                _playerView.SetSkin(index);
                _isApplied[index].SetActive(true);
            }
            else
            {
                SoundsManager.Instance.PlaySound("Not");
            }
        }
        else
        {
            SaveData.Instance.Data.AppliedSkinIndex = index;
            SaveData.Instance.SaveYandex();

            for (int i = 0; i < (_isApplied.Count); i++)
            {
                _isApplied[i].SetActive(false);
            }
            CheckIsBuy();
            _playerView.SetSkin(index);
            _isApplied[index].SetActive(true);
        }
    }
}
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
    [SerializeField] private int _current_levl;

    [Header("Grids")]
    [SerializeField] private List<Button> _grids;
    [Header("Locks")]
    [SerializeField] private List<GameObject> _notBuy;
    [SerializeField] private List<GameObject> _isBuyBox;
    [SerializeField] private List<GameObject> _isApplied;
    [Header("UplockIndexes")]
    [SerializeField] private List<TextMeshProUGUI> _unlockIndex;
    [Header("PriceTextes")]
    [SerializeField] private List<TextMeshProUGUI> _priceTextes;
    [Header("Prices")]
    [SerializeField] private List<int> _prices;
    [Header("UnlockLevels")]
    [SerializeField] private List<int> _unlockLevels;

    private void Start()
    {
        for (int _index = 0; _index < (_priceTextes.Count); _index++)
        {
            _priceTextes[_index].text = _prices[_index].ToString();
            _unlockIndex[_index].text = _unlockLevels[_index].ToString();
        }

        foreach (Button _grid in _grids)
        {
            _grid.onClick.AddListener(() => Grid(index: _grids.IndexOf(_grid)));
        }

    }
    public void Back()
    {
        SoundsManager.Instance.PlaySound("Click");
        SoundsManager.Instance.StopSound();
        SoundsManager.Instance.PlayBackGround("1");
    }

    public void LoadShop()
    {
        _scrollbarVertical.value = 1;
        SoundsManager.Instance.StopSound();
        SoundsManager.Instance.PlaySound("OpenShop");
        SoundsManager.Instance.PlayBackGround("InShop");

        _isApplied[SaveData.Instance.Data.AppliedSkinIndex].SetActive(true);

        UIBehaviour.Instance.UpdateCoins(SaveData.Instance.Data.Coins);
        CheckIsBuy();

        _current_levl = (int)SaveData.Instance.Data.FakeLevel;
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
            PlayerViev _playerViev = FindObjectOfType<PlayerViev>();
            _playerViev.SetSkin(index);
            _isApplied[index].SetActive(true);
        }
    }
}
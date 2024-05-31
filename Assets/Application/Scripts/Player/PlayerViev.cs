using System.Collections.Generic;
using UnityEngine;

public class PlayerViev : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cars;
    private void Start()
    {
        PlacingSkin(SaveData.Instance.Data.AppliedSkinIndex);
    }
    private void PlacingSkin(int index)
    {
        foreach (var car in _cars)
        {
            car.SetActive(false);
        }

        _cars[index].SetActive(true);
    }
    public void SetSkin(int index)
    {
        PlacingSkin(index);
    }    
}

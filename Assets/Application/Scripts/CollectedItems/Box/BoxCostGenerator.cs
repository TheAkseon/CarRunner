using System.Collections.Generic;
using UnityEngine;

public class BoxCostGenerator : MonoBehaviour
{
    private List<Box> _boxes = new();

    private void Start()
    {
        _boxes.AddRange(FindObjectsOfType<Box>());

        GenerateCost();
    }

    public void GenerateCost()
    {
        foreach(Box box in _boxes)
        {
            int randomCost = Random.Range(2, 5);
            box.GetComponent<Box>().SetCost(randomCost);
        }
    }
}
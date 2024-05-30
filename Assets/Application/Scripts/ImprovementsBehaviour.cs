using System;
using UnityEngine;

public class ImprovementsBehaviour : MonoBehaviour
{
    public static ImprovementsBehaviour Instance;

    public float CostMultiplier = 1.2f;

    public int CostOfDamageImprovements = 10;  // ����� ���������
    public int CostOfFiringRateImprovements = 20;  // ����� ���������

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        CostOfDamageImprovements = SaveData.Instance.Data.CostOfDamageImprovements;
        CostOfFiringRateImprovements = SaveData.Instance.Data.CostOfFiringRateImprovements;
        UpdateView();
    }

    public void IncreaseCostOfDamageImprovements()
    {
        CostOfDamageImprovements = Convert.ToInt32(CostOfDamageImprovements * CostMultiplier);
        SaveData.Instance.Data.CostOfDamageImprovements = CostOfDamageImprovements;
        SaveData.Instance.SaveYandex();
        UpdateView();
    }

    public void IncreaseCostOfFiringRateImprovements()
    {
        CostOfFiringRateImprovements = Convert.ToInt32(CostOfFiringRateImprovements * CostMultiplier);
        SaveData.Instance.Data.CostOfFiringRateImprovements = CostOfFiringRateImprovements;
        SaveData.Instance.SaveYandex();
        UpdateView();
    }

    public void UpdateView()
    {
        Debug.Log("��������� ��������� ������ - " + CostOfDamageImprovements);
        Debug.Log("��������� ��������� �������� �������� - " + CostOfFiringRateImprovements);
        // UIBehaviour.Instance.UpdateImprovements(CostOfFiringRateImprovements, CostOfDamageImprovements);
    }
}

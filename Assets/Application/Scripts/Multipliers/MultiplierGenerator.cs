using UnityEngine;

public class MultiplierGenerator : MonoBehaviour
{
    [SerializeField] private Multipliers _multipliers;
    [SerializeField] private Pedestal _pedestal;
    private readonly Vector3 _multipliersPosition = new Vector3 (0, 0.01f, 95);
    private readonly Vector3 _pedestalPosition = new Vector3(0, -0.1f, 192);

    private void Start()
    {
        SpawnMultipliers();
        SpawnPedestal();
    }

    private void SpawnMultipliers()
    {
        Instantiate(_multipliers, _multipliersPosition, Quaternion.identity);
    }

    private void SpawnPedestal()
    {
        Instantiate(_pedestal, _pedestalPosition, Quaternion.identity);
    }
}

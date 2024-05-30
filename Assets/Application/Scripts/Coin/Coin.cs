using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            CoinManager.Instance.AddMoney(1);
            SoundsManager.Instance.PlaySound("CatchCoin");
            Destroy(gameObject);
            Instantiate(_effectPrefab, transform.position, transform.rotation);
        }
    }
}

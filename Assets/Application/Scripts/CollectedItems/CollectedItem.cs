using UnityEngine;
using UnityEngine.Events;

public class CollectedItem : MonoBehaviour
{
    protected int _cost = 1;
    protected bool _isCollected = false;
    protected bool _isCat = true;
    [SerializeField] private GameObject _collectEffectPrefab;
    [SerializeField] private Transform _particlePosition;

    public int Cost => _cost;
    public GameObject CollectEffectPrefab => _collectEffectPrefab;
    public Transform ParticlePosition => _particlePosition;
    public bool IsCollected => _isCollected;
    public bool IsCat => _isCat;

    public UnityAction<CollectedItem> Collected;

    public void WasCollected()
    {
        _isCollected = true;
    }
}
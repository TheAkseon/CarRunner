using System.Collections.Generic;
using UnityEngine;

public class PlayerViev : MonoBehaviour
{
    [SerializeField] private GameObject _playerMesh;
    [SerializeField] private GameObject _hairMesh;
    [SerializeField] private List<Material> _casualMaterials;
    [SerializeField] private List<Material> _hairMaterials;
    [SerializeField] private List<Mesh> _hairMeshes;
    private void Start()
    {
        PlacingSkin(_index: SaveData.Instance.Data.AppliedSkinIndex);
    }
    private void PlacingSkin(int _index)
    {
        SkinnedMeshRenderer _playerMeshRenderer = _playerMesh.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer _hairMeshRenderer = _hairMesh.GetComponent<SkinnedMeshRenderer>();

        switch (_index)
        {
            case 0:
                _playerMeshRenderer.material = _casualMaterials[0];
                _hairMeshRenderer.material = _hairMaterials[0];
                _hairMeshRenderer.sharedMesh = _hairMeshes[0];
                break;
            case 1:
                _playerMeshRenderer.material = _casualMaterials[5];
                _hairMeshRenderer.material = _hairMaterials[0];
                _hairMeshRenderer.sharedMesh = _hairMeshes[2];
                break;
            case 2:
                _playerMeshRenderer.material = _casualMaterials[2];
                _hairMeshRenderer.material = _hairMaterials[1];
                _hairMeshRenderer.sharedMesh = _hairMeshes[0];
                break;
            case 5:
                _playerMeshRenderer.material = _casualMaterials[3];
                _hairMeshRenderer.material = _hairMaterials[2];
                _hairMeshRenderer.sharedMesh = _hairMeshes[1];
                break;
            case 4:
                _playerMeshRenderer.material = _casualMaterials[4];
                _hairMeshRenderer.material = _hairMaterials[2];
                _hairMeshRenderer.sharedMesh = _hairMeshes[0];
                break;
            case 3:
                _playerMeshRenderer.material = _casualMaterials[1];
                _hairMeshRenderer.material = _hairMaterials[0];
                _hairMeshRenderer.sharedMesh = _hairMeshes[1];
                break;
        }
    }
    public void SetSkin(int _index)
    {
        SkinnedMeshRenderer _playerMeshRenderer = _playerMesh.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer _hairMeshRenderer = _hairMesh.GetComponent<SkinnedMeshRenderer>();

        PlacingSkin(_index: _index);
    }    
}

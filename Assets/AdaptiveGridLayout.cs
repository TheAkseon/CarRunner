using UnityEngine;
using UnityEngine.UI;

public class AdaptiveGridLayout : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private RectTransform _containerRectTransform;

    public void UpdateGridLayout()
    {
        float width = _containerRectTransform.rect.width;
        float height = _containerRectTransform.rect.height;

        _gridLayoutGroup.cellSize = new Vector2(width / 3.1f, height / 3.9f);
    }
}

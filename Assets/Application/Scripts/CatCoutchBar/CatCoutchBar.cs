using UnityEngine;
using UnityEngine.UI;

public class CatCoutchBar : MonoBehaviour
{
    public static CatCoutchBar Instance;
    [SerializeField] private float _catAddCount;
    [SerializeField] public float ProgressCoutchCat = 0f;
    [SerializeField] public GameObject CatBarFill;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void MathfAddColl()
    {
        CatCollector catCollector = FindObjectOfType<CatCollector>();
        _catAddCount = 1f / (float)catCollector.CatCount;
        Debug.Log(_catAddCount + " равен catAddCount");
    }
    public void fillBar()
    {
        CatBarFill.GetComponent<Image>().fillAmount = CatBarFill.GetComponent<Image>().fillAmount + _catAddCount;
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBehaviour : MonoBehaviour
{
    public static LevelBehaviour Instance;

    [SerializeField] CoinManager _coinManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void NextLevel()
    {
        int next = SaveData.Instance.Data.CurrentLevel + 1;

        if (next < 12 && SaveData.Instance.Data.FakeLevel < 12)
        {
            SaveData.Instance.Data.FakeLevel = next;
            SaveData.Instance.Data.CurrentLevel = next;
            SaveData.Instance.Save();
        }
        else
        {
            SaveData.Instance.Data.FakeLevel += 1;
            next = Random.Range(2, 12);
            SaveData.Instance.Data.CurrentLevel = next;
            SaveData.Instance.Save();
        }

        LevelLoader.Instance.UnloadScene();
        LevelLoader.Instance.LoadLevel(next);
    }

    public void Restart()
    {
        LevelLoader.Instance.LoadLevel(SaveData.Instance.Data.CurrentLevel);
    }
}

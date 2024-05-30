using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    public static PlayerModifier Instance;
    //[SerializeField] private AudioSource _increaseSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Die()
    {
        UIBehaviour.Instance.GameOver(true);
        gameObject.SetActive(false);
    }

    public void Reberth()
    {
        gameObject.SetActive(true);
    }
}

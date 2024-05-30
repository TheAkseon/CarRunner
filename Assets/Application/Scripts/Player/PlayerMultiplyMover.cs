using System.Collections;
using UnityEngine;

public class PlayerMultiplyMover : MonoBehaviour
{
    public static PlayerMultiplyMover Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void MultiplierCoroutine(float multiplierValue, Multiplier multiplier, int collectedMoney)
    {
        StartCoroutine(GoToMultiplier(multiplierValue, multiplier, collectedMoney));
    }

    private IEnumerator GoToMultiplier(float multiplierValue, Multiplier multiplier, int collectedMoney)
    {
        Pedestal pedestal = FindObjectOfType<Pedestal>();
        ConfettiSpawner confettiSpawner = FindObjectOfType<ConfettiSpawner>();

        float time = 1f;
        float elapsedTime = 0f;
        int confettiCount = 3;

        Vector3 pedestalPosition = pedestal.transform.position;
        Vector3 startingPos = transform.position;
        Vector3 targetPosition = new Vector3(0, 0, transform.position.z + Mathf.CeilToInt(multiplierValue));
        
        if (multiplierValue == 100)
        {
            targetPosition = new Vector3(0, 0.53f, pedestalPosition.z);
            confettiCount = 5;
        }

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, targetPosition, ( elapsedTime / time ));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, 180, 0);
        PlayerAnimationController.Instance.Dance();
        multiplier.MultiplyMoney(collectedMoney);
        confettiSpawner.SpawnConfetti(transform, confettiCount);
        UIBehaviour.Instance.Victory();
    }
}
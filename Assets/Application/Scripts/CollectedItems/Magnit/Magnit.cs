using System.Collections;
using UnityEngine;

public class Magnit : MonoBehaviour
{
    [SerializeField] public float work_time = 5.0f;
    public void On()
    {
        UIBehaviour.Instance.StartTimer();
        gameObject.SetActive(true);
        StartCoroutine(WorkTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Cat")
        {
            other.gameObject.GetComponent<CatMagnit>().enabled = true;
        }
    }
    IEnumerator WorkTime()
    {
        yield return new WaitForSeconds(work_time);
        gameObject.SetActive(false);
        // StopCoroutine(WorkTime());
    }
}

using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer_text;

    private float _timeLeft = 0f;
    private bool _timerOn = false;

    private void Start()
    {
        _timeLeft = FindObjectOfType<Magnit>().work_time;
        // _timeLeft = 5.0f;
        _timerOn = true;
        StartCoroutine(CorTimer());
    }
    IEnumerator CorTimer()
    {
        while (_timerOn)
        {
            if (_timeLeft >= 0)
            {
                Debug.Log("Timer:" + _timeLeft);
                timer_text.text = (Mathf.Round(_timeLeft * 10) / 10f).ToString();
                _timeLeft -= 0.1f;
            }
            else
            {
                _timerOn = false;
                StopCoroutine(CorTimer());
                gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}

using System;
using System.Collections;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class UIBehaviour : MonoBehaviour
{
    public static UIBehaviour Instance;

    [Header("Panels")]
    [SerializeField] GameObject _startMenuPanel;
    [SerializeField] GameObject _inGamePanel;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _casesPanel;
    [SerializeField] CatCoutchBar _catBar;

    [Header("Player")]
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] TextMeshProUGUI _coinText;
    [SerializeField] TextMeshProUGUI _coinText2;

    [Header("Sound")]
    [SerializeField] Button musicButton;
    [SerializeField] Button effectsButton;
    [SerializeField] Sprite notSprite;
    [SerializeField] Sprite yesSprite;

    [Header("Game Over Panel")]
    [SerializeField] GameObject _restartButton;
    [Header("Timer")]
    [SerializeField] private Timer timer;
    [Header("CatsBar")]
    [SerializeField] private float _add_catbar;

    private bool muteMusic;
    private bool muteEffects;
    private GameObject _catBarFill;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _catBar.gameObject.SetActive(false);
        _startMenuPanel.SetActive(true);
        PlayerMove.Instance.StopMovement();
        _levelText.text = SaveData.Instance.Data.FakeLevel.ToString();
        muteEffects = SaveData.Instance.Data.muteEffects;
        muteMusic = SaveData.Instance.Data.muteMusic;

        if (SaveData.Instance.Data.muteMusic == true)
        {
            Image image;
            bool state;
            image = musicButton.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>();
            state = muteMusic;
            SoundsManager.Instance.Mute("music", muteMusic);

            if (!state)
                image.sprite = yesSprite;
            else
                image.sprite = notSprite;
        }

        if (SaveData.Instance.Data.muteEffects == true)
        {
            Image image;
            bool state;
            image = effectsButton.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>();
            state = muteEffects;
            SoundsManager.Instance.Mute("effects", muteEffects);

            if (!state)
                image.sprite = yesSprite;
            else
                image.sprite = notSprite;
        }

    }

    public void Play()
    {
        _catBar.MathfAddColl();

        _startMenuPanel.SetActive(false);
        _inGamePanel.SetActive(true);
        _catBar.gameObject.SetActive(true);
        PlayerMove.Instance.ResumeMovement();
        FindObjectOfType<PlayerBehaviour>().Play();
    }

    public void Mute(string type)
    {
        UnityEngine.UI.Image image;
        bool state;
        if (type.Equals("music"))
        {
            image = musicButton.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>();
            muteMusic = !muteMusic;
            SaveData.Instance.Data.muteMusic = muteMusic;
            state = muteMusic;
            SoundsManager.Instance.Mute(type, muteMusic);
        }
        else
        {
            image = effectsButton.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>();
            muteEffects = !muteEffects;
            SaveData.Instance.Data.muteEffects = muteEffects;
            state = muteEffects;
            SoundsManager.Instance.Mute(type, muteEffects);
        }

        if (!state)
            image.sprite = yesSprite;
        else
            image.sprite = notSprite;

        SaveData.Instance.Save();
#if UNITY_WEBGL && !UNITY_EDITOR
        SaveData.Instance.SaveYandex();
#endif
    }

    public void Victory()
    {
        _catBar.gameObject.SetActive(false);
        _casesPanel.SetActive(true);
    }

    public void BossFight()
    {
        // _inputSlider.SetActive(false);
    }

    private IEnumerator CheckRewarded()
    {
        while (YandexAds.Instance.IsRewarded == false)
        {
            yield return null;
        }

        _gameOverPanel.SetActive(false);
        // _inputSlider.SetActive(true);
        PlayerModifier.Instance.Reberth();
        // PlayerMove.Instance.ResumeMovement();
        // PlayerMove.Instance.ApplyInvulnerable();
        // PlayerAnimationController.Instance.Run();
        YandexAds.Instance.OnAdRewardedFalse();
    }

    /*public void Continue()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Time.timeScale = 0f;
        YandexAds.Instance.ShowRewardAd(1);
        StartCoroutine(CheckRewarded());
#else
        _gameOverPanel.SetActive(false);
        _inputSlider.SetActive(true);
        PlayerModifier.Instance.Reberth();
        // PlayerMove.Instance.ResumeMovement();
        timerAfterAds.TimerStart();
#endif
    }*/

    public void GameOver(bool _isBoss)
    {
        if (_isBoss)
        {
            SoundsManager.Instance.FadeOut();
            SoundsManager.Instance.PlaySound("GameOver");
        }

        _gameOverPanel.SetActive(true);
        // _inputSlider.SetActive(false);
        PlayerMove.Instance.StopMovement();
    }

    /*private void BlockContinueButton()
    {
        _continueButton.SetActive(false);
        _restartButton.GetComponent<RectTransform>().localPosition = new Vector3(0, -440, 0);
    }*/

    public void Restart()
    {
        YandexGame.FullscreenShow();
        LevelBehaviour.Instance.Restart();
    }

    public void Advertisement()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        YandexAds.Instance.ShowRewardAd(1);
#endif
    }

    public void UpdateCoins(int count)
    {
        _coinText.text = count.ToString();
        _coinText2.text = count.ToString();
    }

    // public void UpdateImprovements(int firingRateCost, int damageCost)
    // {
    //     _firingRateCostText.text = firingRateCost.ToString();
    //     _damageCostText.text = damageCost.ToString();
    //     _currentDamage.text = WebBullet.GetDamage().ToString();
    // }

    // public void WebBulletDamageIncrease() => CoinManager.Instance.SpendMoney(ImprovementsBehaviour.Instance.CostOfDamageImprovements, Damage);

    // public void WebBulletFiringRateIncrease() => CoinManager.Instance.SpendMoney(ImprovementsBehaviour.Instance.CostOfFiringRateImprovements, FiringRate);


    public void CoutchCat()
    {
        _catBarFill.GetComponent<Image>().fillAmount = _catBarFill.GetComponent<Image>().fillAmount + _add_catbar;
    }

    public void StartTimer()
    {
        timer.gameObject.SetActive(true);
    }
}
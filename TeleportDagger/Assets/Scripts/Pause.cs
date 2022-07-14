using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static Pause S;
    [SerializeField] private AudioSource audioMain;
    [SerializeField] private GameObject panel;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image audioOnAndOff;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private Coin coinsValue;
    [SerializeField] private Score scoreValue;
    [SerializeField] private Text[] coinText;
    [SerializeField] private Text[] maxScoreText;
    [SerializeField] private ObstacleGeneration obstacleGeneration;
    [SerializeField] private GameObject HeartForAds;
    [SerializeField] private GameObject HeartForMoney; 
    private int coinAddition;
    private const string saveKeyScore = "saveScore";
    private const string saveKeyCoins = "saveCoins";

    private void Start()
    {
        S = this;
        RewardedAds.S.LoadAd();
    }

    public void PauseMenu()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            audioMain.Pause();
            panel.gameObject.SetActive(true);
            Load();
        }
    }

    public void RebirthAds()
    {
        HeartForAds.SetActive(false);
        restartPanel.SetActive(false);
        audioMain.Play();
        obstacleGeneration.ObstacleStartPosition();
        Time.timeScale = 1;
    }

    public void RebirthMoney()
    {
        SaveSpentMoney(1000);
    }

    public void RestartMenu()
    {
        Speed.speed = 1;
        restartPanel.SetActive(true);
        audioMain.Pause();
        Save();
        Load();
        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void OnClickMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickContinue()
    {
        Time.timeScale = 1;
        panel.gameObject.SetActive(false);
        audioMain.Play();
    }
    public void OnClickRestart()
    {
        SceneManager.LoadScene("play");
        restartPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnClickAudioOnAndOf()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0f;
            audioOnAndOff.sprite = sprites[0];
        }
        else
        {
            AudioListener.volume = 1f;
            audioOnAndOff.sprite = sprites[1];
        }

    }

    private void Load()
    {
        var dataScore = SaveSystem.Load<SaveData.PlayerProfile>(saveKeyScore);
        var dataCoins = SaveSystem.Load<SaveData.PlayerProfile>(saveKeyCoins);
        for(int i = 0; i < coinText.Length; i++)
        {
            coinText[i].text = dataCoins.coins.ToString();
        }
        for (int i = 0; i < maxScoreText.Length; i++)
        {
            maxScoreText[i].text = dataScore.maxScore.ToString();
        }
    }

    private bool LoadSpentMoney()
    {
        var dataCoins = SaveSystem.Load<SaveData.PlayerProfile>(saveKeyCoins);
        if(dataCoins.coins >= 1000)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Save()
    {
        var dataScore = SaveSystem.Load<SaveData.PlayerProfile>(saveKeyScore);
        var dataCoins = SaveSystem.Load<SaveData.PlayerProfile>(saveKeyCoins);
        if (dataScore.maxScore < scoreValue.score)
        {
            SaveSystem.Save(saveKeyScore, GetSaveScore());
        }
        coinAddition = dataCoins.coins + coinsValue.coin;
        SaveSystem.Save(saveKeyCoins, GetSaveCoins());
    }

    private void SaveSpentMoney(int spentMoney)
    {
        var dataCoins = SaveSystem.Load<SaveData.PlayerProfile>(saveKeyCoins);
        if (dataCoins.coins >= spentMoney)
        {
            coinAddition = dataCoins.coins - spentMoney;
            SaveSystem.Save(saveKeyCoins, GetSaveCoins());
            HeartForMoney.SetActive(false);
            restartPanel.SetActive(false);
            audioMain.Play();
            obstacleGeneration.ObstacleStartPosition();
            Time.timeScale = 1;
        }
    }

    private SaveData.PlayerProfile GetSaveScore()
    {

        var data = new SaveData.PlayerProfile()
        {
            maxScore = scoreValue.score
        };
        return data;
    }

    private SaveData.PlayerProfile GetSaveCoins()
    {
        var data = new SaveData.PlayerProfile()
        {
            coins = coinAddition
        };
        return data;
    }
}

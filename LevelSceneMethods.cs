using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneMethods : MonoBehaviour
{
    [SerializeField] GameObject levelCan, themeCan, creditsCan, optionsCan, controlspanel;

    public void GameStart()
    {
        SceneManager.LoadScene(sceneName: "MainScene");
        AudioCheck.Instance.GetComponent<AudioSource>().Stop();
    }
    public void ThemeMenu()
    {
        levelCan.SetActive(false);
        themeCan.SetActive(true);
    }
    public void ThemeConfirm()
    {
        themeCan.SetActive(false);
        levelCan.SetActive(true);
    }
    public void Credits()
    {
        levelCan.SetActive(false);
        creditsCan.SetActive(true);
    }
    public void CreditsBack()
    {
        creditsCan.SetActive(false);
        levelCan.SetActive(true);
    }
    public void SunnyDay()
    {
        PlayerPrefs.SetInt("ThemeIndex", 1);
    }
    public void Eclipse()
    {
        PlayerPrefs.SetInt("ThemeIndex", 2);
    }
    public void DryLand()
    {
        PlayerPrefs.SetInt("ThemeIndex", 3);
    }
    public void HighMoutains()
    {
        PlayerPrefs.SetInt("ThemeIndex", 4);
    }
    public void Forest()
    {
        PlayerPrefs.SetInt("ThemeIndex", 5);
    }
    public void RedSoil()
    {
        PlayerPrefs.SetInt("ThemeIndex", 6);
    }
    public void optionsOn()
    {
        levelCan.SetActive(false);
        optionsCan.SetActive(true);
    }
    public void controlson()
    {
        optionsCan.SetActive(false);
        controlspanel.SetActive(true);
    }
    public void controlsoff()
    {
        controlspanel.SetActive(false);
        optionsCan.SetActive(true);
    }
    public void optionsOff()
    {
        optionsCan.SetActive(false);
        levelCan.SetActive(true);
    }
    public void GitHubNavi()
    {
        Application.OpenURL("https://github.com/classicbazingagames/EscapeKnife.git");
    }
    public void Exit()
    {
        Application.Quit();
    }
}

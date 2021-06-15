using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MainSceneMethods : MonoBehaviour
{
    [SerializeField] GameObject gpButtoncan, pauseButton, pauseMenu, player, infoButton, naviInfo;
    SpriteRenderer playerSprite;
    string GooglePlayID = "4148131";
    bool TestMode = false;
    void Start()
    {
        Advertisement.Initialize(GooglePlayID, TestMode);
        playerSprite = player.GetComponent<SpriteRenderer>();
    }
    public void paused()
    {
        Time.timeScale = 0;
        gpButtoncan.SetActive(false);
        pauseButton.SetActive(false);
        infoButton.SetActive(false);
        playerSprite.enabled = false;
        pauseMenu.SetActive(true);
    }
    public void naviInfoPanel()
    {
        Time.timeScale = 0;
        gpButtoncan.SetActive(false);
        infoButton.SetActive(false);
        pauseButton.SetActive(false);
        playerSprite.enabled = false;
        naviInfo.SetActive(true);
    }
    public void resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gpButtoncan.SetActive(true);
        pauseButton.SetActive(true);
        infoButton.SetActive(true);
        playerSprite.enabled = true;
    }
    public void naviInfoDown()
    {
        Time.timeScale = 1;
        naviInfo.SetActive(false);
        gpButtoncan.SetActive(true);
        pauseButton.SetActive(true);
        infoButton.SetActive(true);
        playerSprite.enabled = true;
    }
    public void GameRestart()
    {
        Advertisement.Show();
        SceneManager.LoadScene(sceneName: "MainScene");
        Time.timeScale = 1;
    }
    public void GameExit()
    {
        Advertisement.Show();
        SceneManager.LoadScene(sceneName: "LevelMenu");
        AudioCheck.Instance.GetComponent<AudioSource>().Play();
        Time.timeScale = 1;
    }
}
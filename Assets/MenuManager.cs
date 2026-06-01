using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Camera mainMenuCamera;
    public Camera settingsCamera;
    public Camera skinsCamera;

    public LevelSystem levelSystem;

    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        mainMenuCamera.gameObject.SetActive(true);
        settingsCamera.gameObject.SetActive(false);
        skinsCamera.gameObject.SetActive(false);
    }

    public void ShowSettings()
    {
        mainMenuCamera.gameObject.SetActive(false);
        settingsCamera.gameObject.SetActive(true);
        skinsCamera.gameObject.SetActive(false);
    }

    public void ShowSkins()
    {
        mainMenuCamera.gameObject.SetActive(false);
        settingsCamera.gameObject.SetActive(false);
        skinsCamera.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        mainMenuCamera.gameObject.SetActive(false);
        settingsCamera.gameObject.SetActive(false);
        skinsCamera.gameObject.SetActive(false);
        levelSystem.LoadLevel(0); // This activates Level 1's camera automatically
    }
}
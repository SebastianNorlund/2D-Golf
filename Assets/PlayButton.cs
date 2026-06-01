using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public MenuManager menuManager;

    void OnMouseDown()
    {
        menuManager.StartGame();
    }
}
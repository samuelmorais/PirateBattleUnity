using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void GotoMainMenuScene() {
        SceneManager.LoadScene("MainMenu");
    }
}

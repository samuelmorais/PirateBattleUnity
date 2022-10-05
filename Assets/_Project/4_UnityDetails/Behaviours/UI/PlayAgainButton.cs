using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public void PlayAgain() {
        SceneManager.LoadScene("Game");
    }
}

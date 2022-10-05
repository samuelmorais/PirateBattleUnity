using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OptionsView : MonoBehaviour
{
    [SerializeField]
    GameObject OptionsPanel;

    [SerializeField]
    TMP_InputField inputSessionTime;


    [SerializeField]
    TMP_InputField inputEnemySpawnTime;

    [SerializeField]
    TMP_Text messageText;

    const int DEFAULT_ENEMY_SPAWN_TIME = 1;
    const int DEFAULT_SESSION_TIME = 3;

    void Start() {
        LoadOptions();
    }

    public void OpenOptionsPanel() {
        LoadOptions();
        OptionsPanel.SetActive(true);
    }

    public void SaveOptions() {
        if(ValidateOptions()) {
            PlayerPrefs.SetInt("SessionTime", int.Parse(inputSessionTime.text));
            PlayerPrefs.SetInt("EnemySpawnTime", int.Parse(inputEnemySpawnTime.text));
            CloseOptionsPanel();
        }
    }

    public void CancelOptions() {
        CloseOptionsPanel();
    }

    void CloseOptionsPanel() {
        OptionsPanel.SetActive(false);
    }

    bool ValidateOptions() {
        if(inputSessionTime.text == "" || inputEnemySpawnTime.text == "" || inputSessionTime.text == "0" || inputEnemySpawnTime.text == "0") {
            messageText.text = "Please fill both fields with non-zero.";
            return false;
        }
        messageText.text = "";
        return true;
    }

    public void LoadOptions() {
        if(PlayerPrefs.GetInt("SessionTime") != 0) {
            inputSessionTime.text = PlayerPrefs.GetInt("SessionTime").ToString();
        }
        else {
            PlayerPrefs.SetInt("SessionTime", DEFAULT_SESSION_TIME);
        }
        if(PlayerPrefs.GetInt("EnemySpawnTime") != 0) {
            inputSessionTime.text = PlayerPrefs.GetInt("EnemySpawnTime").ToString();
        }
        else {
            PlayerPrefs.SetInt("EnemySpawnTime", DEFAULT_ENEMY_SPAWN_TIME);
        }
        messageText.text = "";
    }
}

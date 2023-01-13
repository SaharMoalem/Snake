using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject mainMenu;

    [SerializeField] GameObject gameOverMenu;

    [SerializeField] GameObject pointsDuringGame;
    [SerializeField] GameObject highScoreTable;
    [SerializeField] TMP_Text newHighscoreText;

    void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pointsDuringGame.SetActive(false);
        highScoreTable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        GameManager.instance.ShowPlayer();
    }

    public void ShowGameOverMenu() {
        gameOverMenu.SetActive(true);
        pointsDuringGame.SetActive(false);
    }

    public void ShowNewHighscoreText() {
        newHighscoreText.gameObject.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }
}

using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject objectToCatch;
    [SerializeField] private GameObject objectToAvoid;
    private float timeElapsed;
    [SerializeField] private float spawnInterval;
    private int currentScore = 0;
    [SerializeField] private int winScore;
    [SerializeField] private float loseScore;
    [SerializeField] private UIDocument scoreDisplay;
    [SerializeField] private UIDocument startMenu;
    [SerializeField] private UIDocument endScreen;
    [SerializeField] private GameObject EndUI;
    [SerializeField] private GameObject MenuUI;
    bool GameActive = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowStartMenu();
    }

    void ShowStartMenu()
    {
        EndUI.SetActive(false);
        MenuUI.SetActive(true);
        Button StartGameButton = startMenu.rootVisualElement.Q<Button>(name = "StartGame");
        StartGameButton.clicked += InitializeGame;
        Button QuitGameButton = startMenu.rootVisualElement.Q<Button>(name = "QuitGame");
        QuitGameButton.clicked += QuitGame;
    }

    void InitializeGame()
    {
        MenuUI.SetActive(false);
        GameActive = true;
        timeElapsed = 0f;
        currentScore = 0;
        IncrementScore(0);

    }

    private void QuitGame()
    {
        // This code runs only in the Unity Editor
        if (Application.isEditor)
        {
            EditorApplication.isPlaying = false;
        }
        // This code runs in a built application (Windows, Mac, Linux, etc.)
        else
        {
            Application.Quit();
        }

    }
  
    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= spawnInterval && GameActive == true)
        {
            SpawnSomething();
        }
    }

    static GameObject GetRandomSpawnPoint(GameObject[] spawnPoints)
    {
        int length = spawnPoints.Length;

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            throw new ArgumentException("Array cannot be null or empty.", nameof(spawnPoints));
        }

        int next = UnityEngine.Random.Range(0, length);
        return spawnPoints[next];
    }

    void SpawnSomething()
    {
        //decide which type of object to spawn

        //to do

        //get a random spawn point and spawn that object there
        Vector3 position = new Vector3();
        position = GetRandomSpawnPoint(spawnPoints).transform.position;

        Instantiate(objectToCatch, position, quaternion.identity);

        timeElapsed = 0f;
    }

    public void IncrementScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + score);
        Label scoreCounter = scoreDisplay.rootVisualElement.Q<Label>(name = "ScoreValue");
        scoreCounter.text = currentScore.ToString();

        if (currentScore >= winScore)
        {
            EndGame(true);
        }
        else if (currentScore <= loseScore)
        {
            EndGame(false);
        }
    }

    public void EndGame(bool PlayerWon)
    {
        GameActive = false;
        EndUI.SetActive(true);
        Button EndText = endScreen.rootVisualElement.Q<Button>(name = "GameOver");

        if (PlayerWon)
        {
            EndText.text = "You Win!";
        }
        else
        {
            EndText.text = "You Lose!";
        }

        EndText.clicked += ShowStartMenu;

    }

}

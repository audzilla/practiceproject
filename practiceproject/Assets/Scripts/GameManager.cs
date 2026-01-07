using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject objectToCatch;
    [SerializeField] private GameObject objectToAvoid;
    private float timeElapsed;
    [SerializeField] private float spawnInterval;
    private int currentScore = 0;
    [SerializeField] private int targetScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeElapsed = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= spawnInterval)
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
        if (currentScore >= targetScore)
        {
            //todo: game ends!
            Debug.Log("Stopping play mode in Editor...");
            EditorApplication.isPlaying = false;
        }
    }
}

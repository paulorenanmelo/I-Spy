using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISpy_BookFactory : MonoBehaviour
{
    [SerializeField] private ISpy_FactoryInput factoryInput;
    [SerializeField] private int seedSpawn = 42;
    [SerializeField] private int seedChosen = 13;
    [SerializeField] private bool SpawnOnStart = true;
    
    [Header("Runtime Only")]
    [SerializeField] private ISpy_FactoryOutput factoryOutput;
    [SerializeField] private List<GameObject> spawnedBooks = new List<GameObject>();

    void Awake()
    {
        if (SpawnOnStart) Spawn();
    }

    public void Spawn()
    {
        if (factoryInput == null)
        {
            Debug.LogError("[ISpy_BookFactory]: factoryInput missing");
            enabled = false;
            return;
        }
        if (factoryOutput == null) factoryOutput = ScriptableObject.CreateInstance<ISpy_FactoryOutput>();
        if (factoryInput.Clear) factoryOutput.Clear();

        var rndBooks = new System.Random(seedSpawn);
        var books = new List<ISpy_Model>();
        var difficulty = factoryInput.difficultyChosen ?? ScriptableObject.CreateInstance<ISpy_Difficulty_Default>();

        for (int i = 0; i < difficulty.spawn; i++)
        {
            var rand = rndBooks.Next(0, factoryInput.possibleBooks.Length);
            var book = factoryInput.possibleBooks[rand];
            var go = book.Spawn(transform);
            spawnedBooks.Add(go);
            books.Add(book);
        }
        factoryOutput.spawnedBooks = books.ToArray();

        var rndChosenBooks = new System.Random(seedChosen);
        var chosenBooks = new List<ISpy_Model>();
        for (int i = 0; i < difficulty.chosenBooks; i++)
        {
            var rand = rndBooks.Next(0, factoryOutput.spawnedBooks.Length);
            var book = factoryOutput.spawnedBooks[rand];
            chosenBooks.Add(book);
        }
        factoryOutput.chosenBooks = chosenBooks.ToArray();
    }
}
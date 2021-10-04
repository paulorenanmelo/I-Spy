using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ISpy_GameController : MonoBehaviour
{
    /// <summary>
    /// Unsafe. Can be null if there is no object in the scene, or if it is off
    /// </summary>
    public static ISpy_GameController instance;

    /// <summary>
    /// Runtime data
    /// </summary>
    [SerializeField] ISpy_FactoryOutput factoryOutput;
    [SerializeField] UnityEvent hitChosenBookEvent;
    [SerializeField] UnityEvent gameOverEvent;
    [SerializeField] UnityEvent gameWinEvent;
    [SerializeField] ISpy_Stats stats;

    private void Start()
    {
        if(stats != null)
        {
            stats.Score = factoryOutput.chosenBooks.Length;
            stats.BooksChosenCorrectly = 0;
        }
    }
    private void OnEnable()
    {
        instance = this;
    }

    private void OnDisable()
    {
        if (instance != this) return;
        instance = null;
    }

    void Update()
    {
        if (!factoryOutput.IsValidRuntime) return;

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                var bookHit = factoryOutput.spawnedBooks.FirstOrDefault(x => hit.transform.gameObject.name.Contains(x.Model.name));
                if(bookHit != null && bookHit.Model != null)
                {
                    hit.transform.gameObject.SetActive(false);
                    if (factoryOutput.chosenBooks.Contains(bookHit))
                    {
                        hitChosenBookEvent?.Invoke();
                        stats.BooksChosenCorrectly++;
                    }
                    else
                    {
                        stats.Score--;
                    }

                    if(stats.Score < factoryOutput.spawnedBooks.Length - factoryOutput.chosenBooks.Length)
                    {
                        gameOverEvent?.Invoke();
                    }
                    else if (stats.BooksChosenCorrectly >= factoryOutput.chosenBooks.Length - 1)
                    {
                        gameWinEvent?.Invoke();
                    }
                }
            }
        }
    }
}

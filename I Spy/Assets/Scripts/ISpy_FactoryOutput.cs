using UnityEngine;

/// <summary>
/// Runtime objects
/// </summary>
[CreateAssetMenu]
public class ISpy_FactoryOutput : ISpy_ScriptableObject
{
    public ISpy_Model[] spawnedBooks;
    public ISpy_Model[] chosenBooks;

    public bool IsValidRuntime
    {
        get
        {
            return spawnedBooks != null && spawnedBooks.Length > 0 && chosenBooks != null && chosenBooks.Length > 0;
        }
    }

    public void Clear()
    {
        spawnedBooks = null;
        chosenBooks = null;
    }
}
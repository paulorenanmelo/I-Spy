using UnityEngine;

/// <summary>
/// Runtime objects
/// </summary>
[CreateAssetMenu]
public class ISpy_FactoryOutput : ISpy_ScriptableObject
{
    public ISpy_Model[] spawnedBooks;
    public ISpy_Model[] chosenBooks;

    public void Clear()
    {
        if (spawnedBooks != null) DestroyObjects(spawnedBooks);
        if (chosenBooks != null) DestroyObjects(chosenBooks);
        spawnedBooks = null;
        chosenBooks = null;
    }

    /// <summary>
    /// Todo: check if that crashes when unloading, quitting, changing application focus, etc.
    /// </summary>
    private void DestroyObjects(UnityEngine.Object[] objects)
    {
        if (objects != null)
        {
            for (int i = objects.Length - 1; i > 0; i--)
            {
                if (objects[i] != null)
                {
                    Destroy(objects[i]);
                }
            }
        }
    }
}
using UnityEngine;

[CreateAssetMenu]
public class ISpy_Difficulty : ISpy_ScriptableObject
{
    [Range(1, 100)]
    public int spawn;
    [Range(1, 100)]
    public int chosenBooks;
}
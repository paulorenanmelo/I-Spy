using UnityEngine;

[CreateAssetMenu]
public class ISpy_FactoryInput : ISpy_ScriptableObject
{
    [Tooltip("Prefabs or assets that can be spawned")]
    public ISpy_Model[] possibleBooks;
    public ISpy_Difficulty difficultyChosen;
    [Tooltip("When starting the game, should the output be cleared?")]
    public bool Clear = true;
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ISpy_UIController : MonoBehaviour
{
    [SerializeField] ISpy_FactoryOutput _factoryOutput;
    [SerializeField] ISpy_Stats stats;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] Transform hintParent;
    [SerializeField] GameObject prefabHint;
    [SerializeField] bool spawnHintsOnStart = true;

    private void Start()
    {
        if (spawnHintsOnStart)
        {
            SpawnHints(_factoryOutput);
        }
    }

    public void SpawnHints(ISpy_FactoryOutput factoryOutput)
    {
        if (factoryOutput == null) return;
        for (int i = 0; i < factoryOutput.chosenBooks.Length; i++)
        {
            if (factoryOutput.chosenBooks[i].clue == null || factoryOutput.chosenBooks[i].clue.Length == 0) continue;
            
            for (int j = 0; j < factoryOutput.chosenBooks[i].clue.Length; j++)
            {
                var go = Instantiate(prefabHint, hintParent);
                var tmp = go.GetComponent<TextMeshProUGUI>();
                if (tmp)
                {
                    tmp.text = factoryOutput.chosenBooks[i].clue[j];
                }
            }
        }
    }

    private void OnGUI()
    {
        if (stats == null) return;
        score.text = stats.Score.ToString();
    }
}

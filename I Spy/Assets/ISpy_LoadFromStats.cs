using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ISpy_LoadFromStats : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    [SerializeField] private ISpy_Stats stats;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        if (stats != null)
        {
            tmp.text = stats.Score.ToString();
        }
    }
}

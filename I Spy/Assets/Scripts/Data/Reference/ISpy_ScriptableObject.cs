using UnityEngine;

public class ISpy_ScriptableObject : ScriptableObject
{
    public static implicit operator string(ISpy_ScriptableObject v)
    {
        return v.name;
    }

    public static implicit operator ISpy_ScriptableObject(string v)
    {
        return new ISpy_ScriptableObject() { name = v };
    }
}
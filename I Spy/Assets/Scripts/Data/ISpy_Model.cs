using UnityEngine;

[CreateAssetMenu]
public class ISpy_Model : ISpy_ScriptableObject
{
    public GameObject Model;
    public string[] clue;

    public GameObject Spawn(Transform transform)
    {
        var go = Instantiate(Model, transform, false);
        go.transform.localPosition = Random.insideUnitSphere;
        go.transform.rotation = Random.rotation;

        var col = go.AddComponent<MeshCollider>();
        col.convex = true;
        //col.sharedMesh = go.GetComponent<MeshFilter>().sharedMesh;
        go.AddComponent<Rigidbody>();
        Physics.BakeMesh(col.sharedMesh.GetInstanceID(), true);

        return go;
    }
}
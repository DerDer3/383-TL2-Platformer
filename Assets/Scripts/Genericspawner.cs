using UnityEngine;

public class GenericSpawner : MonoBehaviour
{
    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (prefab == null) return null;

        GameObject spawnedObject = Instantiate(prefab, position, rotation);
        return spawnedObject;
    }
}

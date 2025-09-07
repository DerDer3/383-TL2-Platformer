using UnityEngine;

public class GenericSpawner : MonoBehaviour
{
    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (prefab == null)
        {
            Debug.LogWarning("Prefab is null! Cannot spawn.");
            return null;
        }

        GameObject spawnedObject = Instantiate(prefab, position, rotation);
        return spawnedObject;
    }
}

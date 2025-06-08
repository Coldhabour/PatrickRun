using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int numberOfObjects;
    public Collider spawnArea;
    public float minimumDistance = 1.0f;
    public float minimumObjectDistance = 2.0f; // nova variável para definir a distância mínima entre os objetos gerados
    public string avoidTag = "Player";

    private void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = RandomPointInBounds(spawnArea.bounds);
            if (!IsTooClose(randomPosition))
            {
                Instantiate(objectToSpawn, randomPosition, Quaternion.identity, transform);
            }
        }
    }

    private Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    private bool IsTooClose(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, minimumDistance);
        foreach (Collider col in colliders)
        {
            if (col.gameObject.CompareTag(avoidTag) || Vector3.Distance(position, col.transform.position) < minimumObjectDistance)
            {
                return true;
            }
        }
        return false;
    }
}

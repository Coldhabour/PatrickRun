using UnityEngine;

public class SpawnerTerreno : MonoBehaviour
{
    public GameObject terreno;
    Vector3 proximoSpawn;

    // Start is called before the first frame update
    void Start()
    {
      for(int i = 0; i < 5; i++)
        {
            SpawnarTerreno();
        }
    }

    public void SpawnarTerreno()
    {
        GameObject temp = Instantiate(terreno, proximoSpawn, Quaternion.identity);
        proximoSpawn = temp.transform.GetChild(12).transform.position;
    }
}

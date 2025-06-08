using UnityEngine;

public class Moedas : MonoBehaviour
{
    
    public float velocidadeVirada = 90;
    private void OnTriggerExit(Collider other)
    {   
        
        //checa se foi o player
        if (other.gameObject.tag != "Player")
        {
            Destroy(gameObject);
            return;
        }
        GameManager.inst.MuitoDinheiro();
        
        //Destroy Moeda
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(velocidadeVirada * Time.deltaTime, 0, 0);
    }
}

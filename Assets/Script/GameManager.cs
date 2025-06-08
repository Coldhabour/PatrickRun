using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int dinheiro;
    public static GameManager inst;
    public Text textoDinheiro;
    public AudioSource coin;
    public AudioClip myAudioClip;
    // Start is called before the first frame update

    public void MuitoDinheiro()
    {
        dinheiro++;
        coin.PlayOneShot(myAudioClip);
        textoDinheiro.text = ((int)dinheiro).ToString("F0");
    }

    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

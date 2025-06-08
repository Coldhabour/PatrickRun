using UnityEngine;
using UnityEngine.SceneManagement;
public class Logica : MonoBehaviour
{
    public GameObject TelaDeFim;
    public GameObject policial;
    public GameObject player;
    Vector3 diferenca;
    public float Score;
    public float pontosPorSegundo = 20;
    public AudioSource run;
    public AudioSource death;
 
    public void Start()
    {
        diferenca = player.transform.position + policial.transform.position;
       
    }
    public void RestartarJojo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void FimGame()
    {
        TelaDeFim.SetActive(true);
        run.Stop();
        death.Play();
    }
    public void PolicialSegue()
    {
        policial.transform.position = player.transform.position + diferenca;
        
    }
    public void ScoreTime()
    {
        Score += pontosPorSegundo * Time.deltaTime;
 
    }
    public void inicioGame()
    {
        SceneManager.LoadScene(1);
    }
   
}


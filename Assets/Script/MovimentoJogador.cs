using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MovimentoJogador : MonoBehaviour
{
    //velocidade de corrida pra frente
    public float velocidade = 2;
    //velocidade da movimenta��o horizontal
    public float velocidadeHorizontal = 2;
    //coleta o rigidbody do boneco
    public Rigidbody rb;
    //settador de vivo ou morto
    bool Vivo = true;
    //saber o input
    float inputHorizontal;
    //pegar informa��es do script logica
    public Logica logica;
    // contador de hits
    int contadorHit = 0;
    //pegar informa��es do collider
    private Collider col;
    //tempo de dura��o da invunerabilidade do patrick
    float tempoInvulneravel = 3;
    //pega o componente luz no boneco
    private Light luz;
    //pega um elemento de texto
    public Text scoreText;
    //audio do policial
    public AudioSource policeman;
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        luz = GetComponent<Light>();
    }
    void FixedUpdate()
    {
        if (!Vivo) return;

        float inputHorizontal = 0;

        // check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                inputHorizontal = touch.deltaPosition.x * Time.deltaTime;
            }
        }

        // check for mouse input if there's no touch input
        if (Input.GetMouseButton(0))
        {
            inputHorizontal = Input.GetAxis("Mouse X") * velocidadeHorizontal * Time.deltaTime;
        }

        Vector3 andarFrente = transform.forward * velocidade * Time.deltaTime;
        Vector3 andarLado = transform.right * inputHorizontal * velocidadeHorizontal * Time.deltaTime;
        rb.MovePosition(rb.position + andarFrente + andarLado);
        logica.ScoreTime();
        scoreText.text = "PONTUA��O: " + ((int)logica.Score).ToString("F0");
    }


    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barreira")
        {
            contadorHit += 1;
            StartCoroutine(FreezeYPosition());
            StartCoroutine(PolicialSeguindo());
            
            if (contadorHit == 2)
            {
                Morto();
                Time.timeScale = 0f;
            }

        }
    }
    private void Morto()
    {
        Vivo = false;
        logica.FimGame();

    }
    IEnumerator FreezeYPosition()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        col.isTrigger = true;
        if (contadorHit < 2)
        {
            luz.intensity = 1;
            policeman.Play();
        }
        yield return new WaitForSeconds(tempoInvulneravel);

        // Remove freeze Y position and isTrigger constraints
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        col.isTrigger = false;
        luz.intensity = 0;
    }
    IEnumerator PolicialSeguindo()
    {
        float tempoSeguindo = 0;
        while (tempoSeguindo < 5) // executa o loop enquanto o tempoSeguindo for menor que 3 segundos
        {
            logica.PolicialSegue(); // atualiza a posi��o do policial
            tempoSeguindo += Time.deltaTime; // aumenta o tempoSeguindo a cada frame
            yield return null; // aguarda o pr�ximo frame
        }
    }

}

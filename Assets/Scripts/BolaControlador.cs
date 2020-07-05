using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BolaControlador : MonoBehaviour
{
    [SerializeField]
    private float ftVelocidade = 1f, ftVelocidadeMax = 2f;
    [SerializeField]
    private Rigidbody rb;
    public static bool gameOver = false;
    [SerializeField]
    private int numMoedasColetadas;
    [SerializeField]
    private Text txtMoedas;
    [SerializeField]
    private GameObject Particulas;
    [SerializeField]
    private GameObject coin;

    //Painel de GameOver
    [SerializeField]
    private Image imgFundo, imgBtnJogarNovamente;
    [SerializeField]
    private Text txtGameOver, txtBtnJogarNovamente;
    private bool show;

    private void Awake()
    {
        SceneManager.sceneLoaded += Carrega;
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        gameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        numMoedasColetadas = PlayerPrefs.GetInt("numMoedas");
        txtMoedas.text = numMoedasColetadas.ToString();

        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(ftVelocidade, 0, 0);

        StartCoroutine(ajustaVelocidade());

        txtGameOver = GameObject.FindWithTag("txtGameOver").GetComponent<Text>();
        txtBtnJogarNovamente = GameObject.FindWithTag("txtBtnJogarNovamente").GetComponent<Text>();
        imgBtnJogarNovamente = GameObject.FindWithTag("imgBtnJogarNovamente").GetComponent<Image>();
        imgFundo = GameObject.FindWithTag("imgFundo").GetComponent<Image>();

        txtGameOver.enabled = false;
        txtBtnJogarNovamente.enabled = false;
        imgBtnJogarNovamente.enabled = false;
        imgFundo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            bolaMove();
        }
        
        if (!Physics.Raycast(transform.position, Vector3.down, 1))
        {
            gameOver = true;
            rb.useGravity = true;
        }

        if (gameOver)
        {
            PlayerPrefs.SetInt("numMoedas", numMoedasColetadas);
            imgFundo.enabled = true;
            imgBtnJogarNovamente.enabled = true;
            txtGameOver.enabled = true;
            txtBtnJogarNovamente.enabled = true;
        }
    
    }

    void bolaMove()
    {
        if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, ftVelocidade);
        }
        else if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(ftVelocidade, 0, 0);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Moeda"))
        {
            Destroy(col.gameObject);
            numMoedasColetadas++;
            txtMoedas.text = numMoedasColetadas.ToString();
            Instantiate(coin, col.transform.position, Quaternion.identity);
            //Instantiate(Particulas, col.transform.position, Quaternion.identity);
        }
    }

    IEnumerator ajustaVelocidade()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(2);

            if (ftVelocidade <= ftVelocidadeMax)
            {
                ftVelocidade += 0.2f;
            }
            
        }   
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene(0);
    }
}

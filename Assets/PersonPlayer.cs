using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersonPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Text getInText;
    public GameObject cameraCar;
    CarPlayer carPlayer;
    [SerializeField] List<Enemy> enemy;
    [SerializeField] int cantEnemy;
    public GameObject carGameOjbect;
    [SerializeField] float timeLeft;
    [SerializeField] GameObject[] AcessGetIt;
    int i;
    [SerializeField] float paralizadoTime;
    [SerializeField] Text WinCanva;
    [SerializeField] bool powerUp;
    [SerializeField] float coolDownPowerUp;
    [SerializeField] Text SlowMotion;
    [SerializeField] Text paralizado;
    [SerializeField] Text GameOver;
    [SerializeField] GameObject restarButton;
    // Start is called before the first frame update
    void Start()
    {
        restarButton.SetActive(false);
        GameOver.enabled = false;
        Time.timeScale = 1;
        getInText.enabled = true;
        cantEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        WinCanva.enabled = false;
        powerUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        getInText.text = "Time left: " + timeLeft.ToString("F1");
        if(timeLeft < 0)
        {
            restarButton.SetActive(true);
            GameOver.enabled = true;
            Time.timeScale = 0;
        }
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move, Space.World);

        Vector3 mousePosition = Input.mousePosition;

        // Convertir la posici�n del cursor de la pantalla al mundo
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane plane = new Plane(Vector3.up, 0); // Plane en el eje Y
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);

            // Calcular la direcci�n desde el personaje hacia el cursor
            Vector3 direction = target - transform.position;

            // Mantener la direcci�n en el plano XZ (ignorar el eje Y)
            direction.y = 0f;

            // Calcular la rotaci�n requerida para que el personaje mire hacia la direcci�n
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Aplicar la rotaci�n al personaje
            transform.rotation = rotation;

            
        }
       if(Input.GetKeyDown(KeyCode.E) && powerUp)
        {
            coolDownPowerUp = 5;
            powerUp = false;
            Time.timeScale = 0.3f;
            StartCoroutine(CoolDownPowerUp());
        }
       if(coolDownPowerUp <= 0)
        {
            SlowMotion.color = Color.blue;
            SlowMotion.text = "SlowMotion: Activate with E";
        }
        if (coolDownPowerUp > 0)
        {
            coolDownPowerUp -= Time.deltaTime;
            SlowMotion.color = Color.red;
            SlowMotion.text = "SlowMotion: " + coolDownPowerUp.ToString("F1");
        }
        paralizadoTime -= Time.deltaTime;
        if (paralizadoTime > 0)
        {
            paralizado.color = Color.red;
            paralizado.text = "Paralizado: " + paralizadoTime.ToString("F2");
        }
        if (paralizadoTime <= 0)
        {
            paralizado.color = Color.green;
            paralizado.text = "Movil";
            moveSpeed = 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            carGameOjbect = other.gameObject;
            for(int i = 0; i < enemy.Count; i++)
            {
                enemy[i].SetTargetCar();
            }
            
            carPlayer = other.gameObject.GetComponent<CarPlayer>();
            cameraCar = carPlayer.cameraCar;
            cameraCar.gameObject.SetActive(true);
            CarControl sCarControl = other.gameObject.GetComponent<CarControl>();
            sCarControl.playerIn = true;
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Acess"))
        {
            AcessGetIt[i].SetActive(true);
            i++;
            other.gameObject.SetActive(false);
            if (i == 3)
            {
                restarButton.SetActive(true);
                WinCanva.enabled = true;
                Time.timeScale = 0;
            }
        }
        if (other.gameObject.CompareTag("Bala"))
        {
            paralizadoTime = 2;
            moveSpeed = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {     
        
    }
    IEnumerator timerParalizado()
    {
        yield return new WaitForSeconds(paralizadoTime);
    }
    IEnumerator CoolDownPowerUp()
    {
        yield return new WaitForSeconds(coolDownPowerUp);
        powerUp = true;
        Time.timeScale = 1;
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}

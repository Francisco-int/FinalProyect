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

    // Start is called before the first frame update
    void Start()
    {
        getInText.enabled = true;
        cantEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        getInText.text = "Time left: " + timeLeft.ToString("F1");
        if(timeLeft < 0)
        {
            SceneManager.LoadScene(0);
        }
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move, Space.World);

        Vector3 mousePosition = Input.mousePosition;

        // Convertir la posición del cursor de la pantalla al mundo
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane plane = new Plane(Vector3.up, 0); // Plane en el eje Y
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);

            // Calcular la dirección desde el personaje hacia el cursor
            Vector3 direction = target - transform.position;

            // Mantener la dirección en el plano XZ (ignorar el eje Y)
            direction.y = 0f;

            // Calcular la rotación requerida para que el personaje mire hacia la dirección
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Aplicar la rotación al personaje
            transform.rotation = rotation;

            
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
    }

    private void OnTriggerExit(Collider other)
    {

    }
}

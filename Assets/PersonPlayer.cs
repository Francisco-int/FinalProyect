using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PersonPlayer : MonoBehaviour
{
        public float moveSpeed = 5f;
    public Text getInText;
    public GameObject cameraCar;
    CarPlayer carPlayer;
    // Start is called before the first frame update
    void Start()
    {
        getInText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            Debug.Log("fff");
            getInText.enabled = true;
             carPlayer = other.gameObject.GetComponent<CarPlayer>();
            cameraCar = carPlayer.cameraCar;
            gameObject.SetActive(false);
                //GameObject carControl = other.gameObject.GetComponent<GameObject>();
                //transform.position = carControl.transform.position;
                cameraCar.gameObject.SetActive(true);
                CarControl sCarControl = other.gameObject.GetComponent<CarControl>();
                sCarControl.playerIn = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        getInText.enabled = false;
    }
}

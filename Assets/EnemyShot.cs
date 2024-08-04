using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float intervalShot;
    [SerializeField] GameObject proyectil;
    [SerializeField] Transform pointShot;
    public bool ableDisparo;
    public float forceShot;
    RaycastHit hit;
    [SerializeField] float range;
    public Transform player;
    public bool disparoParalizado;
    [SerializeField] GameObject particulas;
    [SerializeField] AudioSource audioDisparo;

    // Start is called before the first frame update
    void Start()
    {
        disparoParalizado = true;
        ableDisparo = true;
        player = GameObject.Find("Capsule").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 directionToPlayer = player.position - transform.position;

        if (Physics.Raycast(transform.position, directionToPlayer, out hit, range))
        {
            if (ableDisparo == true && hit.collider.gameObject.CompareTag("Player"))
            {
                audioDisparo.Play();
                Instantiate(particulas, transform.position, transform.rotation);
                ableDisparo = false;
                StartCoroutine(Disparo());
                Debug.Log("Disparo Metodo llamado");
            }
        }


    }
    IEnumerator Disparo()
    {
        if (disparoParalizado)
        {
        Debug.Log("Disparo");
        GameObject newBala = Instantiate(proyectil, pointShot.transform.position, Quaternion.identity);
        Rigidbody rb = newBala.GetComponent<Rigidbody>();
        rb.AddForce(pointShot.forward * forceShot, ForceMode.Impulse);
        yield return new WaitForSeconds(intervalShot);
        ableDisparo = true;
        }
        
    }
  }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunaVehicular : MonoBehaviour
{

    public float intervalShot;
    [SerializeField] GameObject proyectil;
    [SerializeField] Transform pointShot;
    [SerializeField] bool ableDisparo;
    public float forceShot;



    // Start is called before the first frame update
    void Start()
    {
        ableDisparo = true;
    }

    // Update is called once per frame
    void Update()
    {
       
if (Input.GetMouseButton(0) && ableDisparo == true)
        {
            ableDisparo = false;
            StartCoroutine(Disparo());
            Debug.Log("Disparo Metodo llamado");
        }
        
            
    }
    IEnumerator Disparo()
    {
        Debug.Log("Disparo");
        GameObject newBala = Instantiate(proyectil, pointShot.transform.position, Quaternion.identity);
        Rigidbody rb = newBala.GetComponent<Rigidbody>();
        rb.AddForce(pointShot.forward * forceShot, ForceMode.Impulse);
        yield return new WaitForSeconds(intervalShot);
        ableDisparo = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CarPlayer : MonoBehaviour
{

    [SerializeField] int vida;
    [SerializeField] GunaVehicular gunaVehicular;
    [SerializeField] float powerUpTimer;
    [SerializeField] Transform restart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
if (transform.position.y <= -20)
        {
            transform.position = restart.position;
        } 
        

            
    }
    private void OnCollisionEnter(Collision collision)
    {
       
            //if (collision.gameObject.CompareTag("Bala"))
            //{
            //    vida--;
            //    if(vida == 0)
            //    {
            //        //ff
            //    }
            //}
            if (collision.gameObject.CompareTag("Force"))
            {
                StartCoroutine(ForceShot());
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.CompareTag("Interval"))
            {
                StartCoroutine(InvertaloShot());
                Destroy(collision.gameObject);
            }
        
            
    }

    IEnumerator InvertaloShot()
    {
        gunaVehicular.intervalShot = 0.3f;
        yield return new WaitForSeconds(powerUpTimer);
        gunaVehicular.intervalShot = 0.7f;
    }

    IEnumerator ForceShot()
    {
        gunaVehicular.forceShot = 17000;
        gunaVehicular.intervalShot = 1f;
        yield return new WaitForSeconds(powerUpTimer);
        gunaVehicular.intervalShot = 0.7f;
        gunaVehicular.forceShot = 10000;
    }
}
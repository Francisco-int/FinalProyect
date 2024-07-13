using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CarPlayer : MonoBehaviour
{

    [SerializeField] int vida;
    [SerializeField] float powerUpTimer;
    public GameObject cameraCar;
    public GameObject pointGetOut;
    public GameObject player;
    public CarControl carControl;
    [SerializeField] Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        carControl = GetComponent<CarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {          
            if (Input.GetKeyDown(KeyCode.R))
            {
                carControl.playerIn = false;
                player.transform.position = pointGetOut.transform.position;
                player.gameObject.SetActive(true);
                //enemy.targetff = player.gameObject;
                cameraCar.SetActive(false);
            }
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;           
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
            //if (collision.gameObject.CompareTag("Force"))
            //{
            //    StartCoroutine(ForceShot());
            //    Destroy(collision.gameObject);
            //}
            //if (collision.gameObject.CompareTag("Interval"))
            //{
            //    StartCoroutine(InvertaloShot());
            //    Destroy(collision.gameObject);
            //}
        
            
    }

    //IEnumerator InvertaloShot()
    //{
    //    gunaVehicular.intervalShot = 0.3f;
    //    yield return new WaitForSeconds(powerUpTimer);
    //    gunaVehicular.intervalShot = 0.7f;
    //}

    //IEnumerator ForceShot()
    //{
    //    gunaVehicular.forceShot = 17000;
    //    gunaVehicular.intervalShot = 1f;
    //    yield return new WaitForSeconds(powerUpTimer);
    //    gunaVehicular.intervalShot = 0.7f;
    //    gunaVehicular.forceShot = 10000;
    //}
}
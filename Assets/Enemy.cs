using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [SerializeField] float paralizadoTime;
    public NavMeshAgent enemy;
    [SerializeField] GameObject target;
    public PersonPlayer personPlayer;
    public CarPlayer carPlayer;
    public GameObject targetff;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FollowUpdate", 1, 1);
        target = GameObject.Find("Capsule").gameObject;
        personPlayer = GameObject.Find("Capsule").GetComponent<PersonPlayer>();
        player = GameObject.Find("Capsule").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            target = player;
        }
    }
    void FollowUpdate()
    {
        enemy.SetDestination(target.transform.position);
    }
    public void SetTargetCar()
    {
        target = personPlayer.carGameOjbect;
    }
    public void setPlayer()
    {
        target = player.gameObject;
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
    IEnumerator timerParalizado()
    {
        yield return new WaitForSeconds(paralizadoTime);
        enemy.speed = 3.5f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            enemy.speed = 0;
            StartCoroutine(timerParalizado());
        }

        //    if (other.gameObject.CompareTag("Player"))
        //    {
        //        enemy.speed = 0;
        //    }
        //}
        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.gameObject.CompareTag("Player"))
        //    {
        //        enemy.speed = 3.5f;
        //    }
        //}
    }
}

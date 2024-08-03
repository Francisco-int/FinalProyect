using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] Animator animator;
    [SerializeField] bool paralizado;
    [SerializeField] EnemyShot enemyShot;
    [SerializeField] float cerca;
    [SerializeField] float distancia;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FollowUpdate", 1, 1);
        target = GameObject.Find("Capsule").gameObject;
        personPlayer = GameObject.Find("Capsule").GetComponent<PersonPlayer>();
        player = GameObject.Find("Capsule").gameObject;
        paralizado = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            target = player;
        }
        distancia = Vector3.Distance(player.transform.position, transform.position);
        if(distancia <= cerca)
        {
            animator.SetInteger("WalkLeft", 0);
            animator.SetInteger("WalkBack", 0);
            animator.SetInteger("WalkFront", 0);
            animator.SetInteger("WalkRight", 0);
        }
    }
    void FollowUpdate()
    {
        if (paralizado == false)
        {
            animator.SetInteger("WalkLeft", 0);
            animator.SetInteger("WalkBack", 0);
            animator.SetInteger("WalkRight", 0);
            animator.SetInteger("WalkFront", 1);
            enemy.SetDestination(target.transform.position);

        }
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
        enemyShot.disparoParalizado = true;
        paralizado = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            paralizado = true;
            target = null;
            animator.SetInteger("WalkLeft", 0);
            animator.SetInteger("WalkBack", 0);
            animator.SetInteger("WalkFront", 0);
            animator.SetInteger("WalkRight", 0);
            enemyShot.disparoParalizado = false;
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

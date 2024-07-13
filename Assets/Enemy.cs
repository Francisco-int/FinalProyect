using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    [SerializeField] GameObject target;
    public PersonPlayer personPlayer;
    public CarPlayer carPlayer;
    public GameObject targetff;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FollowUpdate", 1, 1);
        target = GameObject.Find("Capsule").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FollowUpdate()
    {
        enemy.SetDestination(target.transform.position);
    }
    public void SetTargetCar()
    {
        target = personPlayer.carGameOjbect;
    }
    public void SetTargetPlayer()
    {
        Debug.Log("SET");
        targetff = carPlayer.player;

    }
}

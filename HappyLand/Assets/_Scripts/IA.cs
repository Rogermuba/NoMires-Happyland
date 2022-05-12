using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    private Animator anim;
    // Use this for initialization 
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    //Update is called once per frame
    void Update()
    {




    }
    void OnTriggerStay(Collider other)
    {
        nav.SetDestination(player.position);
    }
}
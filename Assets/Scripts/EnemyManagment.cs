using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManagment : MonoBehaviour
{
    [SerializeField] GameObject findPlayer;
    [SerializeField] Animator animator;
    private float damage = 25f;
    private float enemyHealth = 100f;
    [SerializeField] public GameManager gameManager;

    public void Hit(float damage)
    {
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            gameManager.aliveEnemy--;
            Destroy(gameObject);
        }
    }

    void Start()
    {
        findPlayer = GameObject.FindGameObjectWithTag("Player");
        
    }

    
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = findPlayer.transform.position;
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == findPlayer)
        {
            findPlayer.GetComponent<PlayerManagment>().Hit(damage);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagment : MonoBehaviour
{
    [SerializeField] GameObject playerCam;
    [SerializeField] float range = 100f;
    [SerializeField] Animator playerAnimator;
    public float damage = 25f;
    void Start()
    {
        
    }

    
    void Update()
    {

        if (playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);
        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position,transform.forward,out hit, range))
        {
            EnemyManagment enemyManagment = hit.transform.GetComponent<EnemyManagment>();
            if(enemyManagment != null)
            {
                enemyManagment.Hit(damage);
            }
        }
    }
}

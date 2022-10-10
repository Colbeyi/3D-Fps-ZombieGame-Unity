using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManagment : MonoBehaviour
{
    public float health = 100f;
    public float damage = 25f;
    [SerializeField] public Text Health;
    [SerializeField] public GameManager gameManager;
    


    public void Hit(float damage)
    {
        health -= damage;
        Health.text = "Health " + health.ToString();

        if (health <= 0)
        {
            gameManager.EndGame();
        }
    }

}

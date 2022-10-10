using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int aliveEnemy;
    [SerializeField] int round;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Text roundNumber;
    [SerializeField] GameObject endScreen;
    [SerializeField] Text roundSurvived;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        if(aliveEnemy == 0)
        {

            round++;
            NextWave(round);
            roundNumber.text = "Round:" + round.ToString();
        }
        
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void NextWave(int round)
    {
        for(var x = 0; x < round; x++)
        {

            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemySpawned = Instantiate(enemyPrefab,spawnPoint.transform.position,Quaternion.identity);
            enemySpawned.GetComponent<EnemyManagment>().gameManager = GetComponent<GameManager>();
            aliveEnemy++;

        }
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        endScreen.SetActive(true);
        roundSurvived.text = round.ToString();
        
    }
    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}

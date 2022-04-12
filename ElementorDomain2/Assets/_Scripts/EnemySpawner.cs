using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] public GameObject enemy;
    private int enemyCounter;
    private GameObject player;
    public bool someoneCloseToPlayer;
    [SerializeField] public Canvas ui_endgame;

    private float last_spawn_time;

    void Start() {
        someoneCloseToPlayer = false;
        player = GameObject.FindGameObjectWithTag("Player");
        spawnEnemies(5);
    }

    private void spawnEnemies(int numOfEnemies) {
        int i = 0;
        while (i < numOfEnemies) {
            Vector3 pos = new Vector3(player.transform.position.x + Random.Range(-30f, 30f), 1, player.transform.position.z + Random.Range(-30f, 30f));
            if (Vector3.Distance(player.transform.position, pos) >= 15f && insideMap(pos)) {
                Instantiate(enemy, pos, Quaternion.identity);
                i++;
            }
        }
        enemyCounter += numOfEnemies;
    }

    private bool insideMap(Vector3 pos) {
        if (pos.x > -28f && pos.x < 28f && pos.z > -28f && pos.z < 28f) 
            return true;

        return false;
        
    }

    void LateUpdate() {
        if (enemyCounter >= 25 || someoneCloseToPlayer) {
            Debug.Log($"Fim de jogo! {enemyCounter}");
            Instantiate(ui_endgame, new Vector3(0f, 1.77f, 11.83f), Quaternion.identity);
            Time.timeScale = 0f;
            destroyAllEnemies();
        } else if (countEnemiesOnScene() < 3) {
            int r = Random.Range(1, 5);
            spawnEnemies(r);
        }
    }

    private int countEnemiesOnScene() {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void destroyAllEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private float speed;
    private GameObject player;
    private Vector3 direction;
    public int health = 100;
    private bool stunFlag = false;
    private float stunStart;
    private AudioSource dieSound;
    private GameObject spawner;
    private float encostei;

    void Start() {
        speed = Random.Range(0.01f, 0.03f);
        player = GameObject.FindGameObjectWithTag("Player");
        dieSound = GetComponent<AudioSource>();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        encostei = Time.time;
    }

    void LateUpdate() {
        if (stunFlag && (Time.time - stunStart) >= 5f) {
            stunFlag = false;
        }
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= 1 && !stunFlag) {
            player = GameObject.FindGameObjectWithTag("Player");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        } else if (!stunFlag && Time.time - encostei >= 5) {
            spawner.GetComponent<EnemySpawner>().someoneCloseToPlayer = true;
        } else if (!stunFlag) {
            encostei = Time.time;
        }
        if (transform.position.y < 0f) {
            Die();
        }
    }

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Earth")) {
            stunFlag = true;
            stunStart = Time.time;
        } 
    }

    public void Die() {
        dieSound.Play();
        Destroy(this);
    }

    public void takeDamage() {
        health--;
    }
}

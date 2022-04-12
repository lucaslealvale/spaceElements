using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireClass : MonoBehaviour {
    private ParticleSystem fuego;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start() {
        fuego = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

     void OnParticleCollision(GameObject enemy) {
        if (enemy.gameObject.CompareTag("Enemy")) {
            int numCollisionEvents = fuego.GetCollisionEvents(enemy, collisionEvents);

            Rigidbody rb = enemy.GetComponent<Rigidbody>();
            int i = 0;

            while (i < numCollisionEvents) {
                if (rb) {
                    if (enemy.GetComponent<EnemyController>().health == 0) {
                        Destroy(enemy);
                        break;
                    }
                    enemy.GetComponent<EnemyController>().takeDamage();
                    Debug.Log("Dando dano!!!");
                }
                i++;
            }
        }
    }
}

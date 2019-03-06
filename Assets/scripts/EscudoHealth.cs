 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoHealth : MonoBehaviour 
    {
    public int health = 3;

    // Use this for initialization
    void Start () 
    {
		
	}
	
    // Update is called once per frame
    void Update() {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "EnemyBulletTag") {
            health -= 1;
        }
    }
}
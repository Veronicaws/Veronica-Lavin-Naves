using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    GameObject TextScore;

    public AudioClip explosionAudio;
    public GameObject Explosion;

    float speed;

	// Use this for initialization
	void Start ()
    {
        speed = 2f;

        TextScore = GameObject.FindGameObjectWithTag ("textScoreTag");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
      if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
            {

                PlayExplosion();

                TextScore.GetComponent<GameScore>().Score += 100;

                AudioSource.PlayClipAtPoint(explosionAudio, Camera.main.transform.position);

                Destroy(gameObject);
            }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        explosion.transform.position = transform.position;
    }
}

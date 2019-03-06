using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class controlnave : MonoBehaviour
{


    public GameObject GameManager_GO;
    public GameObject Laser;
    public GameObject bulletPosition;
    public GameObject Explosion;
    public AudioClip disparo;

    public Text LivesUIText;

    const int MaxLives = 3;
    int lives;

    public float speed=5f;

    public void Init()
    {
        lives = MaxLives;

        LivesUIText.text = lives.ToString();

        transform.position = new Vector2(0, 0);

        gameObject.SetActive(true);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {

            GameObject Laser01 = (GameObject)Instantiate(Laser);
            Laser01.transform.position = bulletPosition.transform.position;

            AudioSource.PlayClipAtPoint(disparo, Camera.main.transform.position);
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);
    }

    void Move(Vector2 direction)
    {

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.25f;
        min.x = min.x + 0.25f;

        max.y = max.y - 0.25f;
        min.y = min.y + 0.25f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (lives == 0)
            {
                GameManager_GO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

                gameObject.SetActive(false);
            }

        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();

            lives--;
            LivesUIText.text = lives.ToString();


        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        explosion.transform.position = transform.position;

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_timer = 4f;
    [HideInInspector]
    public bool is_EnemyBullet = false;
    // Start is called before the first frame update
    void Start()
    {
        if (is_EnemyBullet)
        {
            speed *= -1f;
        }
        Invoke("DeactivateGameObject", deactivate_timer);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D traget)
    {
        if (traget.tag == "Bullet" || traget.tag == "Enemy")
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        //if (traget.tag == "Bullet" || traget.tag == "Player")
        //{
        //    gameObject.SetActive(false);
        //    Destroy(this.gameObject);
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject Player;
    public GameObject enemy;
    public GameObject hpCanvas;
    public float speed = 1f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private EnemyController enemyCon;
    [SerializeField] private Image hp;
    [SerializeField] private bool touchFlag = false;
    [SerializeField] private bool enemyTouchFlag = false;
    

     void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        hpCanvas.SetActive(false);
    }

    void Update()
    {
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * speed;

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            hpCanvas.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            hpCanvas.SetActive(false);
        }
    }
    
}

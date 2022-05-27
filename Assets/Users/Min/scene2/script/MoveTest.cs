using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public GameObject player;

    public bool playerMove = false;
    private bool Jump = false;

    Rigidbody2D rigid2D;
    float jumpForce = 300.0f;
    public bool enemyTouch = false;
    [SerializeField] private LayerMask enemyLayer;

    public EnemyFollowing EnemyCon;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Jump = false;
    }
    //�����ɒ����܂ŃW�����v�����Ȃ��}��

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //isControlChange = !isControlChange;
        if(GetEnemyLayer())
       {
           if(EnemyCon.isCharging)
           {
               enemyTouch = true;
           }
       }
       else 
       {
           enemyTouch = false;
       }

        
        if (playerMove == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(-0.1f, 0.0f, 0.0f);
                transform.localScale = new Vector3(-0.5f, 0.4710938f, 1);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(0.1f, 0.0f, 0.0f);
                transform.localScale = new Vector3(0.5f, 0.4710938f, 1);
            }

            if (Jump == false && Input.GetKeyDown(KeyCode.Space))
            {
                this.rigid2D.AddForce(transform.up * this.jumpForce);
                Jump = !Jump;
            }
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(enemyTouch)
            {
                EnemyCon.isCharging = false;
            }
        }
    }
     private bool GetEnemyLayer()
    {
        Vector3 left = transform.position + Vector3.up * 1f - Vector3.right * 3.5f;
        Vector3 right = transform.position + Vector3.up * 1f + Vector3.right * 3.5f;
        // �����̃R�����g�����΃f�o�b�O�p�̐��������܂�
        //Debug.DrawLine(left, right);
        return Physics2D.Linecast(left, right, enemyLayer);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public GameObject Player;

    private float x_val;
    private float speed;

    //�v���C���[�̓���̐��l����́i�����A�W�����v�j
    public float inputSpeed;
    public float jumpingPower;
    //
    public LayerMask CollisionLayer;
    [SerializeField] private LayerMask enemyLayer; // ���b�N�ŌF�q:�G��Layer�擾�p
    private bool jumpFlg = false;

    //public Vector2 Speed = new Vector2(1, 1);   //���x
    private int presskeyFrames = 0;             //�������t���[����
    private int PressLong = 300;                 //�����������臒l
    private int PressShort = 100;                //�y�������������臒l
    private bool aa = false;
    Item item;

    [SerializeField] int maxHP = 100;
    [SerializeField] float HP = 100;
    [SerializeField] private bool touchFlag = false;
    [SerializeField] private bool enemyTouchFlag = false; // ���b�N�ŌF�q:�t���O�ǉ�
    public GameObject hpCanvas;
    private float hpCanvasScale_x;

    public bool player_Move = false;

    private bool enemyFollowFlg = false;

    public GameObject enemy;

    //public EnemyController enemyCon;

    // ���b�N�ŌF�q:GetCompornent�d����Œ��Ŏ擾�A�����G�̐�������͂��Ȃ̂ŏ��������邱��
    [SerializeField] private EnemyController enemyCon;
    [SerializeField] private Image hp;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        hpCanvasScale_x = hpCanvas.transform.localScale.x;
        // �F�q:��������Ȃ��Ǝv����
        //enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        // ���b�N�ŌF�q:Layer�ł���Ă����ۂ��̂�Linecast�Ŏ擾
        if (GetEnemyLayer())
        {
            if (enemyCon.isCharging)
            {
                enemyTouchFlag = true;
            }
        }
        else
        {
            enemyTouchFlag = false;
        }


        /*�v���C���[�̈ړ����͏���--------------------------------------------*/
        if(player_Move == false)
        {
            //���L�[�������ꂽ�ꍇ
            x_val = Input.GetAxis("Horizontal");
            jumpFlg = IsCollision();
            //Space�L�[�������ꂽ�ꍇ
            if (Input.GetKeyDown("space") && jumpFlg)
            {
                jump();
            }
        }
        
        /*-----------------------------------------------------------------*/

        /*�E���A������̓��͏���----------------------------------------------------*/
        if (aa)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //�X�y�[�X�̔���
                presskeyFrames += (Input.GetKey(KeyCode.LeftShift)) ? 1 : 0;
                Debug.Log(presskeyFrames);
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                //�����X�y�[�X�����������ꂽ�獂�߂ɓ�����
                if (PressLong <= presskeyFrames)
                {
                    item.Hight();
                    Debug.Log("����");
                    this.gameObject.transform.DetachChildren();
                }
                //�����X�y�[�X�������ꂽ���߂ɓ�����
                else if (PressShort <= presskeyFrames)
                {
                    item.Low();
                    Debug.Log("�Z��");
                    this.gameObject.transform.DetachChildren();
                }
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                this.gameObject.transform.DetachChildren();
            }
        }
        /*-----------------------------------------------------------------*/

        /*�̗͂̌�������-----------------------------------------------------------------*/
        if (touchFlag || enemyTouchFlag)
        {
            // �\��
            hpCanvas.SetActive(true);

            // �d�C�𗬂�
            if (Input.GetKeyDown(KeyCode.Return))
            {
                HP -= 30;// HP�����炷
                // ���b�N�ŌF�q:HP�o�[
                hp.fillAmount = HP / maxHP;
                Debug.Log(HP);
                
                // ���b�N�ŌF�q:�ǉ����܂���
                // �G��Ă��镨��Enemy�̏ꍇ
                if (enemyTouchFlag)
                {
                    // �Ǐ]�J�n
                    enemyCon.isFollowing = true;
                    // �[�d�����̂ł���ȏ�[�d�o���Ȃ��悤��
                    enemyCon.isCharging = false;
                    hpCanvas.SetActive(false);
                }
                
            }
            // �d�C���[�d
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                HP += 30;// HP�𑝂₷
                Debug.Log(HP);
                // �����ɏ�����������

                if(enemyFollowFlg)
                {

                }
            }
        }
        // ���b�N�ŌF�q:HP�\������Object���痣�ꂽ�狭���I��HP�o�[���\���ɂ��܂�
        else
        {
            hpCanvas.SetActive(false);
        }
        /*-----------------------------------------------------------------*/
    }

    /*�v���C���[�̕�������--------------------------------------------------*/
    void FixedUpdate()
    {
        //�ҋ@
        if (x_val == 0)
        {
            speed = 0;
        }
        //�E�Ɉړ�
        else if (x_val > 0)
        {
            speed = inputSpeed;
            transform.localScale = new Vector3(1, 1, 1);//�E����������
            // ���b�N�ŌF�q:HP�o�[�̌����̒���
            Vector3 hpTransform = new Vector3(hpCanvasScale_x, hpCanvas.transform.localScale.y, hpCanvas.transform.localScale.z);
            hpCanvas.transform.localScale = hpTransform;
        }
        //���Ɉړ�
        else if (x_val < 0)
        {
            speed = inputSpeed * -1;
            transform.localScale = new Vector3(-1, 1, 1);//������������
            // ���b�N�ŌF�q:HP�o�[�̌����̒���
            Vector3 hpTransform = new Vector3(-hpCanvasScale_x, hpCanvas.transform.localScale.y, hpCanvas.transform.localScale.z);
            hpCanvas.transform.localScale = hpTransform;
        }
        // �L�����N�^�[���ړ� Vextor2(x���X�s�[�h�Ay���X�s�[�h(���̂܂�))
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }
    /*-----------------------------------------------------------------*/


    /*-----------------------------------------------------*/
    void jump()
    {
        rb2d.AddForce(Vector2.up * jumpingPower);
        jumpFlg = false;
    }
    /*------------------------------------------------------------------*/

    /*�����W�����v��h������------------------------------------------------*/
    bool IsCollision()
    {
        Vector3 left_SP = transform.position - Vector3.right * 0.2f;
        Vector3 right_SP = transform.position + Vector3.right * 0.2f;
        Vector3 EP = transform.position - Vector3.up * 1.3f;
        return Physics2D.Linecast(left_SP, EP, CollisionLayer)
               || Physics2D.Linecast(right_SP, EP, CollisionLayer);
    }
    /*-------------------------------------------------------------------*/

    /// <summary>
    /// �G�̃��C���[�����邩�ǂ������擾����֐�
    /// </summary>
    /// <returns></returns>
    private bool GetEnemyLayer()
    {
        Vector3 left = transform.position + Vector3.up * 1f - Vector3.right * 3.5f;
        Vector3 right = transform.position + Vector3.up * 1f + Vector3.right * 3.5f;
        // �����̃R�����g�����΃f�o�b�O�p�̐��������܂�
        //Debug.DrawLine(left, right);
        return Physics2D.Linecast(left, right, enemyLayer);
    }


    /*---------------------------*/
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            aa = false;
            Debug.Log("exit");
        }
    }
    /*-------------------------------------------------------------------*/

    /*-------------------------------------------------------------------*/
    //�A�C�e���ɓ����葱������
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Debug.Log("stay");

            //W�������Ă�����
            if (Input.GetKey(KeyCode.W))
            {
                aa = true;
                //�A�C�e���N���X�̎擾
                item = collision.gameObject.GetComponent<Item>();

                //�A�C�e����Y�����オ��
                // �����ł��̃I�u�W�F�N�g���v���C���[�̎q���ɂ���
                item.gameObject.transform.parent = this.transform;
            }

        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            this.gameObject.transform.DetachChildren();
        }
    }
    /*-------------------------------------------------------------------*/

    /*HP�o�[��\������^�O�̔���-----------------------------------------*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HomeApp")
        {
            touchFlag = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HomeApp")
        {
            touchFlag = false;
            hpCanvas.SetActive(false);
        }

        

    }
    /*-------------------------------------------------------------------*/

}

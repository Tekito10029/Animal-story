using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Edit��Project Settings��Physics2D���̃`�F�b�N
//���̑O�Ƀ��C���[��������ƁA
//�v���C���[�ƃG�l�~�[�ł���Ⴂ�ʐM���ł���悤�ɂȂ��I

//�ƂĂ��ƂĂ�������ȏ��������Ă�

public class EnemyFollowing : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    //public Transform target;
    public float speed = 3.0f;         //���x
    public float stopDistance;         //�~�܂�Ƃ��̋���

    public bool isFollowing = false;   //�Ǐ]���邩�ǂ���

    public MoveTest mt;

    public bool enemyMove = true;      //�G�l�~�[�̓���
    private bool Jump = false;         //�W�����v�p
    private bool Follow = false;       //��x�ڂ̓��͂ł̂��Ă��邩�ۂ�
    public bool isCharging = true;
    Rigidbody2D rigid2D;
    float jumpForce = 300.0f;          //�W�����v��

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Jump = false;
    }
    //�����ɒ����܂ŃW�����v�����Ȃ��}��

    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g��T���o���Ď擾�������
        //player = GameObject.Find("player");
        //enemy = GameObject.Find("enemy");
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector2 targetPos = player.transform.position;
        targetPos.y = transform.position.y;

        //target�̕����Ɍ���
        //�A�j���[�V�����������ɍ��E���]������������ق�
        //transform.LookAt(target);
        //(targetPos);

        //����
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (isFollowing)
        {
            //if(�Ԃ̋������~�܂�Ƃ��̋����ȏ�Ȃ�?)
            if (distance > stopDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                new Vector2(player.transform.position.x, enemy.transform.position.y),
                speed * Time.deltaTime);
            }
            //enemy��player

            // �E
            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            // ��
            else if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            //�W�����v
            if (Jump == false && Input.GetKeyDown(KeyCode.Space))
            {
                this.rigid2D.AddForce(transform.up * this.jumpForce);
                Jump = !Jump;
            }
        }

        //�G�l�~�[�̓����p
        if (enemyMove == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(-0.01f, 0.0f, 0.0f);
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(0.01f, 0.0f, 0.0f);
                transform.localScale = new Vector3(1, 1, 1);
            }

            if (Jump == false && Input.GetKeyDown(KeyCode.Space))
            {
                this.rigid2D.AddForce(transform.up * this.jumpForce);
                Jump = !Jump;
            }
        }

        // �Ǐ]�̐؂�ւ�����
        //if (Input.GetKey(KeyCode.A))
        //{
        //     //GetComponent<EnemyFollowing>().enabled = false;
        //     Following();
        //}

        //������̐؂�ւ�����
        //1��ڂ̐؂�ւ����̓���
        if (Input.GetKeyDown(KeyCode.Pause) && Follow == false)
        {
            //GetComponent<EnemyFollowing>().enabled = false;
            mt.playerMove = !mt.playerMove;
            Following();
            enemyMove = !enemyMove;
            //PlayerChange(); //���ɂ�����������ƂȂ�Ăł��܂���ł����B
            Follow = !Follow;
        }

        //2��ڂ̐؂�ւ����A�v���C���[���������ăG�l�~�[�s����
        //���̏�Ԃ��Ɖ���Enter�����Ă��v���C���[�����������
        else if(Input.GetKeyDown(KeyCode.Delete) && Follow == true)
        {
            //Following();  //����Ȃ̒m��܂���B
            isFollowing = false;
            enemyMove = true;
            mt.playerMove = false;
        }

        //�Ăԃ{�^��(Delete���u��)�����������̓���
        //Follow��؂�ւ��邱�Ƃł�����x�Ǐ]��؂�ւ����ł��邨
        if (Follow == true && Input.GetKeyDown(KeyCode.End))
        {
            //Following();  //�����A�킩��Ȃ��B
            isFollowing = true;
            Follow = !Follow;
        }
    }

    // ���ĒǏ]�̐؂�ւ�����������
    public void Following()
    {
        isFollowing = !isFollowing;
    }

    // ���đ���̐؂�ւ�����������
    public void PlayerChange()
    {
        // �v���C���[�̑�����ł��Ȃ�����
        mt.playerMove = !mt.playerMove;

        // ���쌠��G�Ɉړ�������
        Following();
        enemyMove = !enemyMove;

        //���̏�ԂŌ��̃{�^���������ƁA����؂�ւ��E�Ǐ]�Ȃ�

        // �J�����̒Ǐ]��G�Ɉڂ����N���撣���ăN�������X���͖{�莛
    }
   
}

/*����
�G�̒Ǐ]
�v���C���[�̍��W�Əd�Ȃ��Ă͂����Ȃ��I
�v���C���[�ƃG�l�~�[�́A�����炩�̊Ԃ��J����C���[�W
�i�s�����Ɣ��Α��ɂ��H(�v���C���[���E�ɐi��ł��鎞�͍����ɂ�)
*/

/*
L�{�^���ő���؂�ւ�
���̂��Ƃ͕t���Ă��Ȃ����@�\�I�t?
*/

/*
L�{�^�������������A�{�^���������ƌĂׂ遨�@�\�I��
(����͂���Ȃ������H)��(����炵���ł��悠�Ȃ�)
*/

/*
���̏グ�����A�j���[�V�������܂����x
*/
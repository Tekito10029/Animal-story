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
    public float speed = 3.0f;         //���x
    public float stopDistance;         //�~�܂�Ƃ��̋���

    public bool isFollowing = false;   //�Ǐ]���邩�ǂ���

    public MoveTest mt;
    Rigidbody2D rigid2D;


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
        }

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
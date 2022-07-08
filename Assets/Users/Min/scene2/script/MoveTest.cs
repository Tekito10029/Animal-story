using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    Rigidbody2D rigid2D;

    [Header("Player")]
    [SerializeField] private GameObject player;
    [Header("EnemyFollowing Script")]
    [SerializeField] private EnemyFollowing EnemyCon;
    [Header("Hp Canvas")]
    [SerializeField] private GameObject HpCanvas;
    [Header("Check To Textbar")]
    [SerializeField] private GameObject CheckText;
    [Header("Check To Rock Text")]
    [SerializeField] private GameObject RockCheckText;


    [Header("Player Move Check")]
    public bool playerMove = false;
    [Header("Check to Enemy")]
    public bool touchFlag = false;
    [Header("Rock")]
    public bool RockFlag, RockFlag1, RockFlag2, RockFlag3, RockFlag4 = false;


    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        RockFlag = false;
        RockFlag1 = false;
        RockFlag2 = false;
        RockFlag3 = false;
        RockFlag4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(-0.005f, 0.0f, 0.0f);
                transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(0.005f, 0.0f, 0.0f);
                transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }

        if (touchFlag == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EnemyCon.isFollowing = true;
                CounterScript.coinAmount -= 1;
            }
        }
        else
        {
            HpCanvas.SetActive(false);
        }
        if (CounterScript.coinAmount < 0)
        {
            EnemyCon.isFollowing = false;
        }
        if (RockFlag == true)
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                CounterScript.coinAmount -= 1;
                EnemyCon.isRock = true;
                EnemyCon.isFollowing = false;
                StartCoroutine(rockdestroy());
            }
        }
        if (RockFlag1 == true)
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                CounterScript.coinAmount -= 1;
                EnemyCon.isRock1 = true;
                EnemyCon.isFollowing = false;
                StartCoroutine(rockdestroy1());
            }
        }
        if (RockFlag2 == true)
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                CounterScript.coinAmount -= 1;
                EnemyCon.isRock2 = true;
                EnemyCon.isFollowing = false;
                StartCoroutine(rockdestroy2());
            }
        }
        if (RockFlag3 == true)
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                CounterScript.coinAmount -= 1;
                EnemyCon.isRock3 = true;
                EnemyCon.isFollowing = false;
                StartCoroutine(rockdestroy3());
            }
        }
        if (RockFlag4 == true)
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                CounterScript.coinAmount -= 1;
                EnemyCon.isRock4 = true;
                EnemyCon.isFollowing = false;
                StartCoroutine(rockdestroy4());
            }
        }
        if (EnemyCon.isFollowing == false)
        {
            RockFlag = false;
        }
        if (EnemyCon.isFollowing)
        {
            CheckText.SetActive(false);
        }

    }
    IEnumerator rockdestroy()
    {
        yield return new WaitForSeconds(2);
        if (EnemyCon.stone != null)
        {
            Destroy(EnemyCon.stone.gameObject);
        }
        // Destroy(EnemyCon.enemy.gameObject);
        EnemyCon.isRock = false;
        EnemyCon.isFollowing = true;
    }
    IEnumerator rockdestroy1()
    {
        yield return new WaitForSeconds(2);
        if (EnemyCon.stone1 != null)
        {
            Destroy(EnemyCon.stone1.gameObject);
        }
        EnemyCon.isRock1 = false;
        EnemyCon.isFollowing = true;
    }
    IEnumerator rockdestroy2()
    {
        yield return new WaitForSeconds(2);
        if (EnemyCon.stone2 != null)
        {
            Destroy(EnemyCon.stone2.gameObject);
        }
        // Destroy(EnemyCon.enemy.gameObject);
        EnemyCon.isRock2 = false;
        EnemyCon.isFollowing = true;
    }
    IEnumerator rockdestroy3()
    {
        yield return new WaitForSeconds(2);
        if (EnemyCon.stone3 != null)
        {
            Destroy(EnemyCon.stone3.gameObject);
        }
        // Destroy(EnemyCon.enemy.gameObject);
        EnemyCon.isRock3 = false;
        EnemyCon.isFollowing = true;
    }
    IEnumerator rockdestroy4()
    {
        yield return new WaitForSeconds(2);
        if (EnemyCon.stone4 != null)
        {
            Destroy(EnemyCon.stone4.gameObject);
        }
        // Destroy(EnemyCon.enemy.gameObject);
        EnemyCon.isRock4 = false;
        EnemyCon.isFollowing = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "inosisi")
        {
            touchFlag = true;
            // HpCanvas.SetActive(true);
        }
        if (collision.gameObject.tag == "textcheck")
        {
            HpCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "inosisi")
        {
            touchFlag = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "1")
        {
            if (CounterScript.coinAmount > 0)
            {
                RockFlag = true;
            }
            else if (CounterScript.coinAmount <= 0)
            {
                RockFlag = false;
            }

            RockCheckText.SetActive(true);
        }
        if (collision.gameObject.tag == "2")
        {
            if (CounterScript.coinAmount > 0)
            {
                RockFlag1 = true;
            }

            RockCheckText.SetActive(true);
        }
        if (collision.gameObject.tag == "3")
        {
            if (CounterScript.coinAmount > 0)
            {
                RockFlag2 = true;
            }
            RockCheckText.SetActive(true);
        }
        if (collision.gameObject.tag == "4")
        {
            if (CounterScript.coinAmount > 0)
            {
                RockFlag3 = true;
            }
            RockCheckText.SetActive(true);
        }
        if (collision.gameObject.tag == "5")
        {
            if (CounterScript.coinAmount > 0)
            {
                RockFlag4 = true;
            }
            RockCheckText.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "1")
        {
            RockFlag = false;
            RockCheckText.SetActive(false);
        }
        if (collision.gameObject.tag == "2")
        {
            RockFlag1 = false;
            RockCheckText.SetActive(false);
        }
        if (collision.gameObject.tag == "3")
        {
            RockFlag2 = false;
            RockCheckText.SetActive(false);
        }
        if (collision.gameObject.tag == "4")
        {
            RockFlag3 = false;
            RockCheckText.SetActive(false);
        }
        if (collision.gameObject.tag == "5")
        {
            RockFlag4 = false;
            RockCheckText.SetActive(false);
        }
    }
}

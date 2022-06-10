using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public GameObject projectile;
    public GameObject projectileclone;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Playermovement();
        fireProjectile();

    }
    
    
    
    void Playermovement()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0,speed * Time.deltaTime, 0));
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
    }

    void fireProjectile()
    {
        if(Input.GetKeyDown(KeyCode.Space) && projectileclone == null)
        {
            projectileclone = Instantiate(projectile, new Vector3(Player.transform.position.x,Player.transform.position.y + 0.6f,0), Player.transform.rotation) as GameObject;
        }
    }
}

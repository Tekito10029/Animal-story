using UnityEngine;

public class MoveCharactorController : MonoBehaviour
{
    private float speed = 5.0f;
    private Goal _goal;

    private int _inputAxis = 0;
    
    void Update()
    {
        Vector2 position = transform.position;

        var _HorizontalInput = Input.GetAxisRaw("Horizontal");
        var _VerticalInput = Input.GetAxisRaw("Vertical");
        
        Debug.Log(_HorizontalInput);
        Debug.Log(_VerticalInput);
        
        if (Input.GetKey("left") || _HorizontalInput <= 0.3)
        {
            position.x -= speed;
        }
        if (Input.GetKey("right")|| _HorizontalInput >= -0.3)
        {
            position.x += speed;
        }
        
        transform.position = position;
    }
}

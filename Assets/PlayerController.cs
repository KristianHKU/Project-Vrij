using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float leftScreenPosition;
    private float middleScreenPosition;
    private float rightScreenPosition;

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    [SerializeField] private float Speed = 0.1f;
    [SerializeField] private float maxSpeed = 1f;

    void Start()
    {
        leftScreenPosition = 0f;
        middleScreenPosition = Screen.width / 2f;
        rightScreenPosition = Screen.width;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPosition = Input.mousePosition;

            if (touchPosition.x > middleScreenPosition - Screen.width / 10f && touchPosition.x < middleScreenPosition + Screen.width / 10f)
            {
                Debug.Log("You touched inbetween 40% and 60% " + touchPosition.x);
            }
            else if (touchPosition.x < middleScreenPosition)
            {
                isMovingLeft = true;
            }
            else if (touchPosition.x > middleScreenPosition)
            {
                isMovingRight = true;
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            isMovingLeft = false;
            isMovingRight = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if (isMovingLeft)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * Speed, ForceMode2D.Impulse);
        }
        else if (isMovingRight)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * Speed, ForceMode2D.Impulse);
        }

        Vector2 clampedVelocity = GetComponent<Rigidbody2D>().velocity;
        clampedVelocity.x = Mathf.Clamp(clampedVelocity.x, -maxSpeed, maxSpeed);
        GetComponent<Rigidbody2D>().velocity = clampedVelocity;
    }
}

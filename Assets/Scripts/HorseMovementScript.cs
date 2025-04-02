using UnityEngine;

public class HorseMovementScript : MonoBehaviour
{
    public float speed = 0;
    public bool isMoving = false;

    public void StartMove(float _speed)
    {
        speed = _speed;
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}

using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Move the player acording to the mouse position.
    /// </summary>
    
    [SerializeField] private Transform Player;
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float HorizontalSpeed;

    public float HorizontalMaxPos = 3;
    public float HorizontalMinPos = -3;
    public float HorizontalOffsetVal = 0; 

    public bool isPlayerRotated = false;

    private Vector3 firstPos, endPos;

    void FixedUpdate()
    {
        if (!isPlayerRotated)
        {
            Player.DOLocalMoveZ(Player.transform.position.z + MovementSpeed, 0.2f, false);
        }
        else
        {
            Player.DOLocalMoveX(Player.transform.position.x + MovementSpeed, 0.2f, false);
        }
        Move();
    }

    // Move player left or right depending on the mouse position change.
    private void Move()
    {
        // Get the first mouse position.
        if (Input.GetMouseButton(0))
        {
            float mousePos = (Input.mousePosition.x - (Screen.width / 2));

            if (!isPlayerRotated)
            {
                Player.DOLocalMoveX(Mathf.Clamp(mousePos * HorizontalSpeed + HorizontalOffsetVal, HorizontalMinPos, HorizontalMaxPos), 0.2f, false);
            }
            else
            {
                Player.DOLocalMoveZ(Mathf.Clamp(- mousePos * HorizontalSpeed + HorizontalOffsetVal, HorizontalMinPos, HorizontalMaxPos), 0.2f, false);
            }
            
        }
        
        
    }
}

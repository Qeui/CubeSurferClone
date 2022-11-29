using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public Transform Player;
    public float MovementSpeed;
    public float HorizontalSpeed;
    private Vector3 firstPos, endPos;

    // Update is called once per frame
    void Update()
    {
            Player.DOLocalMoveZ(Player.transform.position.z + MovementSpeed, 0.2f, false);
            Move();
    }

    // Move player left or right depending on the mouse position change.
    private void Move()
    {
        // Get the first mouse position.
        if (Input.GetMouseButton(0))
        {
            float mousePos = (Input.mousePosition.x - (Screen.width / 2));
            Player.DOLocalMoveX(Mathf.Clamp(mousePos * HorizontalSpeed, -3f, 3f) , 0.2f, false);
        }
        
        
    }
}

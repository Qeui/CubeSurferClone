using UnityEngine;
using DG.Tweening;

public class PlayerRotate : MonoBehaviour
{
    
    /// <summary>
    /// Rotate the player and camera when triggered.
    /// </summary>
    
    public Transform Player;
    public Transform CamHolder;
    public PlayerFollow Follow;
    public PlayerMovement Movement;
    
    public int RotateDeg;

    private bool rightTurn = false;
    private bool leftTurn = false;
    private bool isTriggered = false;

    private float HorizontalMaxPos;
    private float HorizontalMinPos;
    private float HorizontalOffsetVal;
    private float CamPosOffsetVal;

    private Vector3 rotate;

    private void OnTriggerEnter(Collider other)
    {
        rotate = new Vector3(other.transform.rotation.x, RotateDeg, other.transform.rotation.z); 

        if(other.tag == "Player" && !isTriggered)
        {

            Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            PlayerStackController stackController = Player.GetComponent<PlayerStackController>();

            if (rightTurn && !leftTurn)
            {
                stackController.SetDirectionForEachCube(transform.right);
            }
            else if (leftTurn && !rightTurn)
            {
                stackController.SetDirectionForEachCube(-transform.right);
            }
            else
            {
                stackController.SetDirectionForEachCube(transform.forward);
            }
            
            Movement.HorizontalMaxPos = HorizontalMaxPos;
            Movement.HorizontalMinPos = HorizontalMinPos;
            Movement.HorizontalOffsetVal = HorizontalOffsetVal;

            Follow.OffsetX.z = CamPosOffsetVal;

            Player.DORotate(rotate, 0.3f);
            CamHolder.DORotate(rotate, 0.3f);

            Follow.playerIsRotated = true;
            Movement.isPlayerRotated = true;
            isTriggered = true;

        }
    }


}

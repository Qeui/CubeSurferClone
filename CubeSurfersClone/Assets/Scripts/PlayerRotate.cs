using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerRotate : MonoBehaviour
{
    public Transform Player;
    public Transform CamHolder;
    public PlayerFollow Follow;
    public PlayerMovement Movement;

    public bool rightTurn = false;
    public bool leftTurn = false;

    public float HorizontalMaxPos;
    public float HorizontalMinPos;
    public float HorizontalOffsetVal;
    public float CamPosOffsetVal;

    public int RotateDeg;
    private Vector3 rotate;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        rotate = new Vector3(other.transform.rotation.x, RotateDeg, other.transform.rotation.z); 
        if(other.tag == "Player" && !isTriggered)
        {
            Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (rightTurn && !leftTurn)
            {
                Player.GetComponent<PlayerStackController>().SetDirectionForEachCube(transform.right);
            }
            else if (leftTurn && !rightTurn)
            {
                Player.GetComponent<PlayerStackController>().SetDirectionForEachCube(-transform.right);
            }
            else
            {
                Player.GetComponent<PlayerStackController>().SetDirectionForEachCube(transform.forward);
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

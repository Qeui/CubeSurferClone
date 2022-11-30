using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class PlayerRotate : MonoBehaviour
{
    public Transform Player;
    public Transform CamHolder;
    public PlayerFollow Follow;
    public PlayerMovement Movement;
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
            Player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
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

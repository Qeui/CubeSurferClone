using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    public Vector3 OffsetZ;
    public Vector3 OffsetX;
    private Vector3 followPos;
    public bool playerIsRotated = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerIsRotated)
        {
            followPos = new Vector3(0, Player.position.y, Player.position.z) + OffsetZ;
        }
        else
        {
            followPos = new Vector3(Player.position.x, Player.position.y, 0) + OffsetX;
        }
        
        transform.DOMove(followPos, 0.2f, false);

    }
}

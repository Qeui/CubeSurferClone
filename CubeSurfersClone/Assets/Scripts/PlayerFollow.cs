using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
        Vector3 followPos = new Vector3(0, Player.position.y, Player.position.z) + Offset;

        transform.DOMove(followPos, 0.2f, false);
        //transform.DOLookAt(Player.position, 0.5f, AxisConstraint.None, Vector3.up);

    }
}

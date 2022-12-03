using UnityEngine;
using DG.Tweening;

public class PlayerFollow : MonoBehaviour
{
    /// <summary>
    /// Player follow for the main camera.
    /// </summary>

    [SerializeField] private Transform Player;

    public Vector3 OffsetZ;
    public Vector3 OffsetX;
    private Vector3 followPos;

    public bool playerIsRotated = false;

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

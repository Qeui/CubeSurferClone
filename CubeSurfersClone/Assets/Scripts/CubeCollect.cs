using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeCollect : MonoBehaviour
{
    public Transform PlayerModel;
    public Transform PlayerHolder;
    public Transform LastCube;
    public Transform Cubes;
    public float PlayerY = 0.5f;
    public float CubeY = 1;
    public bool isPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collect")
        {
            other.tag = "Untagged";
            other.GetComponent<BoxCollider>().isTrigger = false;
            ComponentSetup(other);
            other.transform.parent = PlayerHolder;
            Vector3 otherPos = new Vector3(transform.position.x, transform.position.y + CubeY, transform.position.z);
            other.transform.DOMove(otherPos, 0f, false);
            PlayerY += 1f;
            CubeY++;
            PlayerModel.DOMoveY(PlayerY, 0f, false);
            LastCube = other.transform;
        }

        if(other.tag == "Obstacle")
        {
            if (isPlayer)
            {
                if(LastCube != null)
                {
                    LastCube.GetComponent<CubeCollect>().isPlayer = true;
                }
                else
                {
                    Debug.LogWarning("!!GAME OVER!!");
                }
                int obsPart = other.GetComponent<ObstacleValueHolder>().PartCount;
                PlayerHolder.DOMoveY(PlayerHolder.position.y - obsPart, 0.1f, false);
            }

            other.GetComponent<BoxCollider>().isTrigger = false;
            transform.parent = Cubes;
        }
    }

    private void ComponentSetup(Collider other)
    {
        other.gameObject.AddComponent<CubeCollect>();
        CubeCollect otherCube = other.GetComponent<CubeCollect>();
        otherCube.PlayerHolder = PlayerHolder;
        otherCube.PlayerModel = PlayerModel;
        otherCube.Cubes = Cubes;
    }
}

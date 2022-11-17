using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeCollect : MonoBehaviour
{
    public Transform PlayerModel;
    public Transform PlayerHolder;
    public Transform Cubes;
    public float PlayerY = 0.5f;
    public float CubeY = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            PlayerY+=1f;
            CubeY++;
            PlayerModel.DOMoveY(PlayerY, 0f, false);
        }
        if(other.tag == "Obstacle")
        {
            other.GetComponent<BoxCollider>().isTrigger = false;
            transform.parent = Cubes;
            PlayerHolder.DOMoveY(PlayerHolder.position.y - 1f, 0.1f, false);
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

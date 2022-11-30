using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    [SerializeField] private PlayerStackController playerStackController;
    [SerializeField] private UIMenager uIMenager;
    [SerializeField]private bool isPlayer = false;
    private bool isStack = false;
    private Collider cubeCollider;
    private RaycastHit hit;
    private Vector3 direction = Vector3.back;

    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
        {
            SetDirection();
        }

        playerStackController = GameObject.FindObjectOfType<PlayerStackController>();
        uIMenager = GameObject.FindObjectOfType<UIMenager>();
        cubeCollider = transform.GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       SetCuberayCast();
    }

    private void SetCuberayCast()
    {
        if (Physics.BoxCast(cubeCollider.bounds.center, transform.lossyScale / 2, direction, out hit, transform.rotation, 0.3f))
        {
            if (!isStack && !isPlayer)
            {
                isStack = true;
                playerStackController.IncreaseCubeStack(gameObject);
                SetDirection();
            }
            if (hit.transform.name == "ObstacleCube" && !isPlayer)
            {
                playerStackController.DecreaseCubeStack(gameObject);
            }
            if (hit.transform.name == "ObstacleCube" && isPlayer)
            {
                uIMenager.GameOverUI();
            }
        }
    }

    private void SetDirection()
    {
        direction = Vector3.forward;
    } 

}

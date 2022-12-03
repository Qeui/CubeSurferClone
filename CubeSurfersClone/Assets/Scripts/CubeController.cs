using UnityEngine;

public class CubeController : MonoBehaviour
{
    /// <summary>
    /// Controls the cube collision
    /// </summary>

    [SerializeField] private PlayerStackController playerStackController;
    [SerializeField] private UIMenager uIMenager;
    [SerializeField] private bool isPlayer = false;

    private bool isStack = false;
    private Collider cubeCollider;

    private RaycastHit hit;
    private Vector3 direction;

    void Start()
    {
        if (isPlayer)
        {
            SetDirection(transform.forward);
        }
        else
        {
            direction = - transform.forward;
        }

        playerStackController = GameObject.FindObjectOfType<PlayerStackController>();
        uIMenager = GameObject.FindObjectOfType<UIMenager>();
        cubeCollider = transform.GetComponent<Collider>();
    }

    void FixedUpdate()
    {
       SetCuberayCast();
    }

    // Conrol the box cast for the cube.
    private void SetCuberayCast()
    {
        if (Physics.BoxCast(cubeCollider.bounds.center, transform.lossyScale / 2, direction, out hit, transform.rotation, 0.3f))
        {
            if (!isStack && !isPlayer)
            {
                isStack = true;
                playerStackController.IncreaseCubeStack(gameObject);
                SetDirection(transform.forward);
            }
            if (hit.transform.name == "ObstacleCube" || hit.transform.name == "FinishCube" && !isPlayer)
            {
                playerStackController.DecreaseCubeStack(gameObject);
            }
            if (hit.transform.name == "ObstacleCube" && isPlayer)
            {
                uIMenager.GameOverUI();
            }
            if (hit.transform.name == "FinishCube" && isPlayer)
            {
                uIMenager.LevelCompleteUI();
            }
        }
    }

    // Set direction to the given direction.
    public void SetDirection(Vector3 givenDirection)
    {
        direction = givenDirection;
    } 

}

using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    /// <summary>
    /// Controls the cube stacking and destacking 
    /// </summary>
    
    private List<GameObject> cubeList = new List<GameObject>();
    private GameObject lastCube;

    void Start()
    {
        UpdateLastCube();
    }


    // Add given cube to the stack.
    public void IncreaseCubeStack(GameObject _gameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

        _gameObject.transform.position = new Vector3(lastCube.transform.position.x, lastCube.transform.position.y - 1f, lastCube.transform.position.z);
        _gameObject.transform.SetParent(transform);
        _gameObject.tag = "Player";

        cubeList.Add(_gameObject);
        UpdateLastCube();
    }

    // Remove given cube from stack.
    public void DecreaseCubeStack(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        cubeList.Remove(_gameObject);
        UpdateLastCube();
    }

    // Set given direction for each cube.
    public void SetDirectionForEachCube(Vector3 givenDirection)
    {
        foreach(GameObject cube in cubeList)
        {
            cube.GetComponent<CubeController>().SetDirection(givenDirection);
        }
    }

    // Update last cube.
    public void UpdateLastCube()
    {
        lastCube = cubeList[cubeList.Count - 1];
    }

}

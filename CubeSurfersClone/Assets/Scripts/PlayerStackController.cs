using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    /// <summary>
    /// This code will be edited so it can be more readble.
    /// </summary>
    
    public List<GameObject> cubeList = new List<GameObject>();
    private GameObject lastCube;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLastCube();
    }

    public void IncreaseCubeStack(GameObject _gameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

        _gameObject.transform.position = new Vector3(lastCube.transform.position.x, lastCube.transform.position.y - 1f, lastCube.transform.position.z);
        _gameObject.transform.SetParent(transform);
        _gameObject.tag = "Player";

        cubeList.Add(_gameObject);
        UpdateLastCube();
    }

    public void DecreaseCubeStack(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        cubeList.Remove(_gameObject);
        UpdateLastCube();
    }

    public void SetDirectionForEachCube(Vector3 givenDirection)
    {
        foreach(GameObject cube in cubeList)
        {
            cube.GetComponent<CubeController>().SetDirection(givenDirection);
        }
    }

    public void UpdateLastCube()
    {
        lastCube = cubeList[cubeList.Count - 1];
    }

}

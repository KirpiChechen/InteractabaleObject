using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{
    private Camera camera;

    private ModeManager modeManager;

    [SerializeField] private GameObject Cube50x50;
    [SerializeField] private GameObject Cube70x30;
    [SerializeField] private GameObject Cube30x70;
    [SerializeField] private GameObject Triangle;

    [SerializeField] private GameObject blade;

    private float startX;
    private float endX;

    private GameObject spawnedBlade;

    private void Start()
    {
        camera = Camera.main;
        modeManager = FindObjectOfType<ModeManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            spawnedBlade = Instantiate(blade, Input.mousePosition, Quaternion.identity);
        }
        if (Input.GetMouseButtonUp(1))
        {
            Destroy(spawnedBlade);
        }
    }

    private void OnMouseEnter()
    {
        RaycastHit hit;

        if (Input.GetMouseButton(1) && Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            startX = hit.point.x;
        }
    }

    private void OnMouseExit()
    {
        RaycastHit hit;

        if (Input.GetMouseButton(1) && Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            endX = hit.point.x;
            SliceCube();
        }
    }

    private void SliceCube()
    {
        if (startX > .1f && endX > .1f)
        {
            GameObject cube = Instantiate(Cube70x30, transform.position, Quaternion.identity);
            modeManager.SetSpawnedCube(cube);
            Destroy(gameObject);
        }
        if (startX < -.1f && endX < -.1f)
        {
            GameObject cube = Instantiate(Cube30x70, transform.position, Quaternion.identity);
            modeManager.SetSpawnedCube(cube);
            Destroy(gameObject);
        }
        if (startX > -.1f && startX < .1f && endX > -.1f && endX < .1f)
            {
            GameObject cube = Instantiate(Cube50x50, transform.position, Quaternion.identity);
            modeManager.SetSpawnedCube(cube);
            Destroy(gameObject);
        }
        if (startX < -.3f && endX > .3f)
        {
            GameObject cube = Instantiate(Triangle, transform.position, Quaternion.identity);
            modeManager.SetSpawnedCube(cube);
            Destroy(gameObject);
        }
        if (startX > .3f && endX < -.3f)
        {
            Vector3 newRotation = new Vector3(0, 0, -90);
            GameObject cube = Instantiate(Triangle, transform.position, Quaternion.Euler(newRotation));
            modeManager.SetSpawnedCube(cube);
            Destroy(gameObject);
        }
        Destroy(spawnedBlade);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeManager : MonoBehaviour
{
    [SerializeField] private Toggle sliceToggle;
    [SerializeField] private Toggle partialDestructionToggle;
    [SerializeField] private Toggle totalDestructionToggle;

    [SerializeField] private GameObject slicePrefab;
    [SerializeField] private GameObject destructibleCube;

    private GameObject spawnedCube;
    public void SliceMode()
    {
        if (spawnedCube != null)
        {
            Destroy(spawnedCube);
            spawnedCube = null;
        }
        spawnedCube = Instantiate(slicePrefab, Vector3.zero, Quaternion.identity);
    }

    public void PartialDestructionMode()
    {
        if (spawnedCube != null)
        {
            Destroy(spawnedCube);
            spawnedCube = null;
        }

        spawnedCube = Instantiate(destructibleCube, Vector3.zero, Quaternion.identity);
        Destroy[] destroys = FindObjectsOfType<Destroy>();

        foreach (Destroy destroy in destroys)
        {
            destroy.TotalDestructionModeOff();
        }
    }

    public void TotalDestructionMode()
    {
        if (spawnedCube != null)
        {
            Destroy(spawnedCube);
            spawnedCube = null;
        }

        spawnedCube = Instantiate(destructibleCube, Vector3.zero, Quaternion.identity);
        Destroy[] destroys = FindObjectsOfType<Destroy>();

        foreach (Destroy destroy in destroys)
        {
            destroy.TotalDestructionModeOn();
        }
    }

    public void SetSpawnedCube(GameObject cube)
    {
        spawnedCube = cube;
    }

    public void Reset()
    {
        if (sliceToggle.isOn)
        {
            SliceMode();
        }
        if (partialDestructionToggle.isOn)
        {
            PartialDestructionMode();
        }
        if (totalDestructionToggle.isOn)
        {
            TotalDestructionMode();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnRoutine()
        {
            while (true)
            {
                Vector3 posToSpawn = GetRandomPositionOutsideBounds();

                GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);

                newEnemy.transform.parent = _enemyContainer.transform;
                
                yield return new WaitForSeconds(2.5f);
            }

        }
    private Vector3 GetRandomPositionOutsideBounds()
    {
        float x, z;

        bool spawnOnX = Random.Range(0, 2) == 0;

        if (spawnOnX)
        {

            x = Random.Range(0, 2) == 0 ? Random.Range(-20f, -12f) : Random.Range(12f, 20f);
            z = Random.Range(-8f, 8f);
        }
        else
        {

            z = Random.Range(0, 2) == 0 ? Random.Range(-15f, -8f) : Random.Range(8f, 15f);
            x = Random.Range(-12f, 12f);
        }

        return new Vector3(x, 0, z);
    }

}

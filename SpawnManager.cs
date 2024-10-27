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
                Vector3 posToSpawn = new Vector3(Random.Range(-9f,9f),0,8);

                GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);

                newEnemy.transform.parent = _enemyContainer.transform;
                
                yield return new WaitForSeconds(5f);
            }

        }

}
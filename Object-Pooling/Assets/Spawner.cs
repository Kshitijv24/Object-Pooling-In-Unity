using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] Transform leftSpawnPoint;
	[SerializeField] Transform rightSpawnPoint;
    [SerializeField] GameObject objectToSpawn;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while(true)
        {
            float randomSpawnPosition = Random.Range(leftSpawnPoint.position.x, rightSpawnPoint.position.x);
            //Instantiate(objectToSpawn, new Vector3(randomSpawnPosition, 4, 0), Quaternion.identity);
            GameObject spawnedObject = ObjectPool.Instance.GetPooledGamedObject();

            if(spawnedObject != null )
            {
                spawnedObject.transform.position = new Vector3(randomSpawnPosition, 4, 0);
                spawnedObject.SetActive(true);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}

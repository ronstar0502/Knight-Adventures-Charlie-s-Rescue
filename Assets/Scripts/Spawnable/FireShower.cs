using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShower : MonoBehaviour
{
    [SerializeField] private GameObject[] fireBallPrefabs;
    [SerializeField] private Transform[] spawnPoints,endPoints;
    [SerializeField] private Transform fireballsParent;
    [SerializeField] private float spawnDelay;


    private void Start()
    {
        StartCoroutine(StartFireballShower());
    }

    private IEnumerator StartFireballShower()
    {
        while (true)
        {
            int randomFireball = Random.Range(0, fireBallPrefabs.Length);
            int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            int randomEndPoint = Random.Range(0, endPoints.Length);

            Vector2 startPos = spawnPoints[randomSpawnPoint].position;
            Vector2 endPos = endPoints[randomEndPoint].position;

            GameObject fireball = Instantiate(fireBallPrefabs[randomFireball], startPos, Quaternion.identity, fireballsParent);
            fireball.GetComponent<Fireball>().SetStartAndEndPoints(startPos, endPos);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

}

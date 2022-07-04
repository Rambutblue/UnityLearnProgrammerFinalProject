using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] slimes;
    bool isCoroutineActive = false;
    [SerializeField]
    private GameObject player;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isCoroutineActive)
        {
            StartCoroutine(Spawner());
            isCoroutineActive = true;
        }
    }
    IEnumerator Spawner()
    {
        spawnTime = Mathf.Sqrt(Slime.score / 50);
        if (spawnTime == 0)
        {
            spawnTime = 1;
        }
        GameObject slime = RandomSlime();
        Vector3 pos = RandomPos();
        while ((pos - player.transform.position).magnitude > 50)
        {
            pos = RandomPos();
        }
        Instantiate(slime, pos, slime.transform.rotation);
        yield return new WaitForSeconds(10 / spawnTime);
        isCoroutineActive = false;

    }
    private GameObject RandomSlime()
    {
        int x = Random.Range(0, slimes.Length);
        return slimes[x];
    }
    private Vector3 RandomPos()
    {
        float x = Random.Range(-255, 255);
        float y = 10;
        float z = Random.Range(-255, 255);
        return new Vector3(x, y, z);
    }
    
}

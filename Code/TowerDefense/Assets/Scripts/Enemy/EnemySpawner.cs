using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Wave[] waves;
    public Wave[] waves1;
    public Transform START;
    public Transform START1;
    public GameObject position;
    public GameObject position1;
    public float waveRate = 0.2f;
    public int CountEnemyAlive;
    public int CountEnemyAlive1;
    private Coroutine coroutine;
    private Coroutine coroutine1;
    public GameObject birthEffect;


    void Start()
    {

        int count = 0;
        foreach (Wave wave in waves)
        {
            count += wave.count;
        }
        if (waves1 != null)
        {
            foreach (Wave wave in waves1)
            {
                count += wave.count;
            }
        }
        Debug.Log(count);

        GameManage.totalEnemyNumber = count;
        GameManage.nowEnemyNumber=0;

        coroutine = StartCoroutine(SpawnEnemy());
        if (waves1 != null)
        {
            coroutine1 = StartCoroutine(SpawnEnemy1());
        }
    }


    public void Stop()
    {
        StopCoroutine(coroutine);
        StopCoroutine(coroutine1);
    }
    IEnumerator SpawnEnemy()
    {

        foreach (Wave wave in waves)
        {
            List< Enemy> enemys = new List<Enemy>(wave.count);

            for (int i = 0; i < wave.count; i++)
            {

                GameObject effect = Instantiate(birthEffect, new Vector3 (START.position.x, START.position.y + 2, START.position.z), START.rotation);
                enemys.Add(Instantiate(wave.enemyPrefab, START.position, Quaternion.identity));
                enemys[i].SetPosition(position);
                CountEnemyAlive++;
                if(i!= wave.count-1)
                    yield return new WaitForSeconds(wave.rate);
            }
            while (CountEnemyAlive > 0)
            {
                for(int i = 0; i < enemys.Count; i++)
                {
                    if (enemys[i] == null)
                    {
                        enemys.RemoveAt(i);
                        CountEnemyAlive--;
                        break;
                    }
                }
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(waveRate);
        }
     
    }IEnumerator SpawnEnemy1()
    {

        foreach (Wave wave in waves1)
        {
            List< Enemy> enemys = new List<Enemy>(wave.count);

            for (int i = 0; i < wave.count; i++)
            {

                GameObject effect = Instantiate(birthEffect, new Vector3 (START1.position.x, START1.position.y + 2, START1.position.z), START1.rotation);
                enemys.Add(Instantiate(wave.enemyPrefab, START1.position, Quaternion.identity));
                enemys[i].SetPosition(position1);
                CountEnemyAlive1++;
                if(i!= wave.count-1)
                    yield return new WaitForSeconds(wave.rate);
            }
            while (CountEnemyAlive1 > 0)
            {
                for(int i = 0; i < enemys.Count; i++)
                {
                    if (enemys[i] == null)
                    {
                        enemys.RemoveAt(i);
                        CountEnemyAlive1--;
                        break;
                    }
                }
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(waveRate);
        }
     
    }

}

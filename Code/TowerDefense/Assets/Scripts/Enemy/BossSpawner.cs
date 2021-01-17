using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BossSpawner : MonoBehaviour
{
    public Wave[] Bosses;
    public Wave[] waves;
    public Transform START;
    private Transform Boss2Start;
    public GameObject position;
    public GameObject BackPosition;
    public float waveRate = 0.2f;
    private Coroutine coroutine;
    public GameObject birthEffect;
    public int CountEnemyAlive;
    private Boss boss;
    private Wave[] Bosses2;



    // Start is called before the first frame update
    void Start()
    {
        Bosses2 = new Wave[Bosses.Length];
        for (int i = 0; i < Bosses.Length; i++)
        {
            Bosses2[i] = Bosses[i];
        }

        coroutine = StartCoroutine(SpawnBoss());

    }




    void Update()
    {
        Bosses2 = new Wave[Bosses.Length];
        for (int i = 0; i < Bosses.Length; i++)
        {
            Bosses2[i] = Bosses[i];
        }
    }

    public void Stop()
    {
        StopCoroutine(coroutine);
    }



    IEnumerator SpawnBoss()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                GameObject effect = Instantiate(birthEffect, new Vector3(START.position.x, START.position.y + 2, START.position.z), START.rotation);
                Debug.Log(Bosses2[0]==null);
                Enemy friend = Instantiate(Bosses2[0].enemyPrefab, START.position, Quaternion.identity);
                friend.SetPosition(BackPosition);
                yield return new WaitForSeconds(10);
            }
            else if (i == 1)
            {
                GameObject effect = Instantiate(birthEffect, new Vector3(START.position.x, START.position.y + 2, START.position.z), START.rotation);
                boss = (Boss)Instantiate(Bosses2[1].enemyPrefab, START.position, Quaternion.identity);
                boss.SetPosition(position);
                while (!Boss.isTouched)
                {
                    yield return 0;

                }
                Boss2Start = boss.transform;
                boss.Die();

            }
            else
            {   
               
                Boss2 Boss2 = (Boss2)Instantiate(Bosses2[2].enemyPrefab, Boss2Start.position, Quaternion.identity);
                Boss2.SetPosition(position);
                StartCoroutine(SpawnEnemy());


            }

        }


        yield return 0;
    }


    IEnumerator SpawnEnemy()
    {

        Random ra = new Random();

        while (true)
        {

            ra.Next(0, 5);

            Wave wave = waves[ra.Next(0, 5)];

            List<Enemy> enemys = new List<Enemy>(wave.count);

            for (int i = 0; i < wave.count; i++)
            {

                GameObject effect = Instantiate(birthEffect, new Vector3(START.position.x, START.position.y + 2, START.position.z), START.rotation);
                enemys.Add(Instantiate(wave.enemyPrefab, START.position, Quaternion.identity));
                enemys[i].SetPosition(position);
                CountEnemyAlive++;
                if (i != wave.count - 1)
                    yield return new WaitForSeconds(wave.rate);
            }
            while (CountEnemyAlive > 0)
            {
                for (int i = 0; i < enemys.Count; i++)
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
            yield return new WaitForSeconds(10);
        }
    }
}

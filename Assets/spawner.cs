using System.Numerics;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float[] possibleSpawnPositions = { 164f, 180f, 194f };
    private Transform t;

    void Awake()
    {

        t = GetComponent<Transform>();
    }
    void Start()
    {
        var random = new System.Random();
        for (int i = 0; i <= 4; i++)
        {
            int randomNumber = random.Next(1, possibleSpawnPositions.Length);
            UnityEngine.Vector2 enemyposition = new UnityEngine.Vector2(possibleSpawnPositions[randomNumber], 8);
            UnityEngine.Debug.Log(enemyposition);
            Instantiate(enemyPrefab, enemyposition, transform.rotation);


        }

    }

    // Update is called once per frame

}

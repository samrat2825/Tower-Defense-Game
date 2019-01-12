using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wavespawner : MonoBehaviour {

    // INITIALIZED TO INSTANTIATE THE ENEMYPREFAB
    public Transform enemyPrefab;

    // INSTANTIATE TO TRANSFORM 
    public Transform spawnpoint;

    public float timebetweenwaves = 1f;

    private float countdown = 2f;

    // USED TO DISPLAY THE SCORE
    public Text WavecountdownTimer;

    // USED TO CONTINOUSLY SPAWN INCREASING AMOUNT OF ENEMIES WITH TIME 
    private int waveIndex = 0;

        private void Update()
    {
        if(countdown<= 0f)
        {
            StartCoroutine(Spawnwave());
            countdown = timebetweenwaves;
        }

        countdown -= Time.deltaTime;

        WavecountdownTimer.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator Spawnwave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
    }

}

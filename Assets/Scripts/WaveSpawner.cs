using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    public Text waveCountdownText;

    void Update()
    {
        if (!GameManagerScript.GameIsOver) {
            if (countdown <= 0f) {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }
            countdown -= Time.deltaTime;

            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
            waveCountdownText.text = string.Format("{0:00.00}", countdown) + " s";
        } 
    }

    IEnumerator SpawnWave() {
        waveIndex++;
        Debug.Log("New wave spawned. Wave Number -> " + waveIndex.ToString());
        PlayerStats.Rounds = waveIndex;
        Debug.Log("PlayerStats.Rounds -> " + PlayerStats.Rounds.ToString());
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

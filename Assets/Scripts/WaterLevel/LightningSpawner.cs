using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpawner : MonoBehaviour
{
    public GameObject spotLightPrefab; // Spot ışığının prefab'ı
    public GameObject lightningPrefab; // Yıldırımın prefab'ı
    public float spotDuration = 2f; // Spot ışığının gösterim süresi (saniye)
    public float lightningDuration = 0.5f; // Yıldırımın gösterim süresi (saniye)
    public float spawnInterval = 2.5f; // Yıldırım spawn aralığı (saniye)

    private float spawnX; // Yıldırımın spawn edileceği x konumu
    private bool spawning = false; // Yıldırım spawn işleminin kontrolü

    private void Start()
    {
        // İlk spot ışığını oluştur ve yıldırım spawn işlemine başla
        SpawnSpotLight();
    }

    private void Update()
    {
        // Yıldırım spawn aralığını kontrol et
        if (!spawning)
        {
            Invoke("SpawnSpotLight", spawnInterval);
            spawning = true;
        }
    }

    private void SpawnSpotLight()
    {
        // Spot ışığını rastgele bir konumda oluştur
        spawnX = Random.Range(-5f, 5f);
        Vector2 randomSpawnPos = new Vector2(spawnX, -2f);
        GameObject spotLight = Instantiate(spotLightPrefab, randomSpawnPos, Quaternion.identity);

        // Spot ışığını belirli bir süre sonra kapat
        Invoke("DisableSpotLight", spotDuration);

        // Yıldırımı aynı konumda spawn et
        Invoke("SpawnLightning", spotDuration);
    }

    private void DisableSpotLight()
    {
        // Tüm spot ışıklarını kapat
        GameObject[] spotLights = GameObject.FindGameObjectsWithTag("SpotLight");
        foreach (GameObject spotLight in spotLights)
        {
            Destroy(spotLight);
        }
    }

    private void SpawnLightning()
    {
        // Spot ışığının olduğu konumda yıldırımı oluştur
        Vector2 spotPos = new Vector2(spawnX, transform.position.y - 0.10f);
        GameObject lightning = Instantiate(lightningPrefab, spotPos, Quaternion.identity);

        // Yıldırımın gösterim süresi boyunca bekleyip sonra yok et
        Destroy(lightning, lightningDuration);

        // Yıldırım spawn işlemi tamamlandı
        spawning = false;
    }
}
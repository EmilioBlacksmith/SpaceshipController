using UnityEngine;

namespace OcelotDev.Spawner
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] Asteroids;
        [SerializeField] private Transform EmptyParent;
        [SerializeField] private float SpawnerXSize, SpawnerYSize;
        [SerializeField] private float BiggestSizeAsteroid;
        [SerializeField] private int CountToSpawn;

        private float SpawnCenterX, SpawnCenterY;

        private void Start()
        {
            SpawnCenterX = SpawnerXSize / 2;
            SpawnCenterY = SpawnerYSize / 2;
            Spawn();
        }

        private void Spawn()
        {
            for(int i = 0; i < CountToSpawn; i++)
            {
                Vector3 PositionToSpawn = new Vector3(Random.Range(-SpawnerXSize, SpawnerXSize),
                    Random.Range(-SpawnerYSize, SpawnerYSize),
                    Random.Range(-SpawnerXSize, SpawnerXSize));

                Quaternion Rotation = Quaternion.Euler(Random.Range(0, 360),
                    Random.Range(0, 360),
                    Random.Range(0, 360));

                float ScaleChange = Random.Range(.1f, BiggestSizeAsteroid);
                Vector3 Size = new Vector3(ScaleChange, ScaleChange, ScaleChange);

                GameObject a = Instantiate(Asteroids[Random.Range(0,Asteroids.Length)], PositionToSpawn, Rotation, EmptyParent) as GameObject;
                a.transform.localScale = Size;
            }
        }
    }
}

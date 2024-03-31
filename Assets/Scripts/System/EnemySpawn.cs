using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform spawnLeftTopCorner;
    [SerializeField] Transform spawnRightDownCorner;
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            createEnemy();
        }
    }
    void createEnemy()
    {
        GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)]);
        float posX = Random.Range(spawnLeftTopCorner.position.x, spawnRightDownCorner.position.x);
        float posY = Random.Range(spawnLeftTopCorner.position.y, spawnRightDownCorner.position.y);
        enemy.transform.position = new Vector2(posX, posY);
    }
}

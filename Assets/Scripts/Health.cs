using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public enum deathAction {loadLevelWhenDead, doNothingWhenDead};
    public float healthPoints = 1f;
    public float respawnHealthPoints = 1f;

    public int numberOfLives = 1;
    public bool isAlive = true;

    public GameObject explosionPrefab;

    public deathAction onLivesGone = deathAction.doNothingWhenDead;

    public string LevelToLoad = "";

    private Vector3 respawnPosition;
    private Quaternion respawnRotation;
    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = transform.position;
        respawnRotation = transform.rotation; 

        if (LevelToLoad=="")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0) {
            numberOfLives--;
            if (explosionPrefab!=null) {
                Instantiate (explosionPrefab, transform.position, Quaternion.identity);
            }
            if(numberOfLives > 0) {
                transform.position = respawnPosition;
                transform.rotation = respawnRotation;
                healthPoints = respawnHealthPoints;
            } else {
                isAlive = false;

                switch(onLivesGone)
                {
                    case deathAction.loadLevelWhenDead:
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                        break;
                    case deathAction.doNothingWhenDead:
                        break;
                }
                Destroy(gameObject);
            }
        }
    }

    public void ApplyDamage(float amount)
    {
        healthPoints = healthPoints - amount;
    }
}

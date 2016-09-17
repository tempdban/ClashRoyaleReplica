using UnityEngine;
using System.Collections;

public class TowerAttack : MonoBehaviour {

    public int playerType;
    public int killEarning;
    public float totalHealth;
    public float damagePerSecond;
    public SpriteRenderer healthBar;
    public SpriteRenderer healthBarBorder;
    public GameObject bullet;
    private bool shouldAttack;
    private float currentHealth;

    void Start()
    {
        //setting up character data
        currentHealth = totalHealth;
        UpdateHealthBar();
        Debug.Log("Total Health: " + totalHealth);
        Debug.Log("Current Health: " + totalHealth);
        healthBar.color = Constants.PLAYER_HEALTH_BAR_COLORS[playerType - 1];
        healthBarBorder.color = Constants.PLAYER_HEALTH_BAR_BORDER_COLORS[playerType - 1];
    }

    IEnumerator SpawnBullets()
    {
        while (shouldAttack)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator DamageEnemyHealth(GameObject enemy)
    {
        while (shouldAttack)
        {
            if (enemy != null)
            {
                if (enemy.GetComponent<CharacterMover>().CurrentHealth - damagePerSecond > 0)
                {
                    enemy.GetComponent<CharacterMover>().CurrentHealth -= damagePerSecond;
                    UpdateHealthBar(enemy);
                    Debug.Log("Remaining Health: " + enemy.GetComponent<CharacterMover>().CurrentHealth);
                    yield return new WaitForSeconds(1.0f);
                }
                else
                {
                    enemy.GetComponent<CharacterMover>().CurrentHealth = 0.0f;
                    UpdateHealthBar(enemy);
                    Debug.Log("Remaining Health: " + enemy.GetComponent<CharacterMover>().CurrentHealth);
                    GameController.Instance.UpdatePlayerRevenue(playerType, enemy.GetComponent<CharacterMover>().killEarning);
                    Destroy(enemy);
                    Debug.Log("Enemy Destroyed");
                    shouldAttack = false;
                    StopCoroutine(SpawnBullets());
                    Debug.Log("All Coroutine stopped");
                    yield break;
                }
            }
            else
            {
                Debug.Log("Enemy Already Dead");
                shouldAttack = false;
                StopCoroutine(SpawnBullets());
                Debug.Log("All Coroutine stopped due to dead enemy");
                yield break;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Character" && (playerType != other.GetComponent<CharacterMover>().playerType))
        {
            shouldAttack = true;
            StartCoroutine(SpawnBullets());
            StartCoroutine(DamageEnemyHealth(other.gameObject));
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Character" && (playerType != other.GetComponent<CharacterMover>().playerType))
        {
            Debug.Log("TriggerExit Called");
            shouldAttack = false;
            StopCoroutine(SpawnBullets());
            StopCoroutine(DamageEnemyHealth(other.gameObject));
            Debug.Log("TriggerExit end");
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.transform.localScale = new Vector3((currentHealth / totalHealth), 1.0f, 1.0f);
    }

    private void UpdateHealthBar(GameObject gameObject)
    {
        gameObject.GetComponent<CharacterMover>().healthBar.transform.localScale = new Vector3((gameObject.GetComponent<CharacterMover>().CurrentHealth / gameObject.GetComponent<CharacterMover>().totalHealth), 1.0f, 1.0f);
    }
}

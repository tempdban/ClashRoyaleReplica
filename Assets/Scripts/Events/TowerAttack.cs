using UnityEngine;
using System.Collections;

public class TowerAttack : Tower 
{
    public float damagePerSecond;
    public GameObject bullet;
    private bool shouldAttack;
	private bool isHealthNotSet;

	void Update ()
	{
		if (GameModel.Instance.AreGameVariableReady && !isHealthNotSet) 
		{
			//setting up character data
			totalHealth = GameController.Instance.UpdateHealthDependingHealthTower(playerType, totalHealth);
			this.CurrentHealth = totalHealth;
			UpdateHealthBar();
			healthBar.color = Constants.PLAYER_HEALTH_BAR_COLORS[playerType - 1];
			healthBarBorder.color = Constants.PLAYER_HEALTH_BAR_BORDER_COLORS[playerType - 1];
			isHealthNotSet = true;
		}

        RaycastHit hit;
        //Create a Ray on the tapped / clicked position
        Ray ray;

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
        {
            Vector3 worldPoint = Vector3.zero;
#if UNITY_EDITOR
            worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //for touch device
#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
				worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif
            Debug.Log("Touch Began");

        }
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            Debug.Log("Touch Ended");
        }
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
//                    Debug.Log("Remaining Health: " + enemy.GetComponent<CharacterMover>().CurrentHealth);
                    yield return new WaitForSeconds(1.0f);
                }
                else
                {
                    enemy.GetComponent<CharacterMover>().CurrentHealth = 0.0f;
                    UpdateHealthBar(enemy);
//                    Debug.Log("Remaining Health: " + enemy.GetComponent<CharacterMover>().CurrentHealth);
                    GameController.Instance.UpdatePlayerRevenue(playerType, enemy.GetComponent<CharacterMover>().killEarning);
                    Destroy(enemy);
                    Debug.Log("Character Destroyed");
                    shouldAttack = false;
                    StopCoroutine(SpawnBullets());
                    yield break;
                }
            }
            else
            {
                shouldAttack = false;
                StopCoroutine(SpawnBullets());
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
            shouldAttack = false;
            StopCoroutine(SpawnBullets());
            StopCoroutine(DamageEnemyHealth(other.gameObject));
        }
    }

    private void UpdateHealthBar()
    {
		healthBar.transform.localScale = new Vector3((this.CurrentHealth / totalHealth), 1.0f, 1.0f);
    }

    private void UpdateHealthBar(GameObject gameObject)
    {
        gameObject.GetComponent<CharacterMover>().healthBar.transform.localScale = new Vector3((gameObject.GetComponent<CharacterMover>().CurrentHealth / gameObject.GetComponent<CharacterMover>().totalHealth), 1.0f, 1.0f);
    }
}

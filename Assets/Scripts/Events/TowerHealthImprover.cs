using UnityEngine;
using System.Collections;

public class TowerHealthImprover : Tower 
{
	public int percentageHealthImprove;

	void Start()
	{
		//setting up character data
		this.CurrentHealth = totalHealth;
		UpdateHealthBar();
		healthBar.color = Constants.PLAYER_HEALTH_BAR_COLORS[playerType - 1];
		healthBarBorder.color = Constants.PLAYER_HEALTH_BAR_BORDER_COLORS[playerType - 1];
	}
    
    void Update()
    {
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
            Debug.Log("Touch Moved");

        }
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            Debug.Log("Touch Moved");
        }
    }

	private void UpdateHealthBar()
	{
		healthBar.transform.localScale = new Vector3((this.CurrentHealth / totalHealth), 1.0f, 1.0f);
	}
}

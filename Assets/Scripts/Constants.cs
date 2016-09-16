using UnityEngine;
using System.Collections;

public class Constants : MonoBehaviour 
{
	public static int PLAYER_1 		=	1;
	public static int PLAYER_2 		=	2;

	public static readonly Color PLAYER_1_HEALTH_BAR_COLOR 			= new Color((float)30/255f, (float)90/255f, (float)250/255f);
	public static readonly Color PLAYER_2_HEALTH_BAR_COLOR 			= new Color((float)242/255f, (float)50/255f, (float)50/255f);
	public static readonly Color PLAYER_1_HEALTH_BAR_BORDER_COLOR 	= new Color((float)1/255f, (float)37/255f, (float)129/255f);
	public static readonly Color PLAYER_2_HEALTH_BAR_BORDER_COLOR 	= new Color((float)128/255f, (float)1/255f, (float)1/255f);

	public static readonly Color[] PLAYER_HEALTH_BAR_COLORS 		= new Color[] {
																		PLAYER_1_HEALTH_BAR_COLOR,
																		PLAYER_2_HEALTH_BAR_COLOR
																	};

	public static readonly Color[] PLAYER_HEALTH_BAR_BORDER_COLORS 	= new Color[] {
																		PLAYER_1_HEALTH_BAR_BORDER_COLOR,
																		PLAYER_2_HEALTH_BAR_BORDER_COLOR
																	};

}

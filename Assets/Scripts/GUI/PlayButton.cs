using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : Button 
{
	#region Unity lifecycle

	public override void OnMouseUp ()
	{
		base.OnMouseUp ();

		GameManager.OnGameStart ();
	}

	#endregion
}

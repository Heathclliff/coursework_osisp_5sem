using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : Button 
{
	#region Unity lifecycle

	public override void OnMouseUp ()
	{
		base.OnMouseUp ();

		GUIManager.Instanse.ShowGameScreen ();
	}

	#endregion
}

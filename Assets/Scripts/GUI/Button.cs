using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	#region Variables

	[SerializeField] SpriteRenderer spriteRenderer;
	[SerializeField] Sprite mouseDownSprite;
	[SerializeField] Sprite mouseUpSprite;

	#endregion

	#region Unity lifecycle

	public virtual void OnMouseDown()
	{
		spriteRenderer.sprite = mouseDownSprite;
	}


	public virtual void OnMouseUp()
	{
		spriteRenderer.sprite = mouseUpSprite;
		SoundManager.Instanse.PlayClick ();
	}

	#endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : Button 
{
	#region Variables

	[SerializeField] SpriteRenderer currentSprite;
	[SerializeField] Sprite musicOnSprite;
	[SerializeField] Sprite musicOffSprite;

	Vector2 musicButtonPosition = new Vector2 (-2.5f, 1000f);

	#endregion


	#region Unity lifecycle

	void Start()
	{
		if(SoundManager.Instanse.IsMusicEnable)
		{
			currentSprite.sprite = musicOnSprite;
		}
		else
		{
			currentSprite.sprite = musicOffSprite;
		}

		this.gameObject.transform.position = musicButtonPosition;
	}

	public override void OnMouseUp ()
	{
		base.OnMouseUp ();

		if (SoundManager.Instanse.IsMusicEnable)
		{
			SoundManager.Instanse.IsMusicEnable = false;
			currentSprite.sprite = musicOffSprite;
		}
		else
		{
			SoundManager.Instanse.IsMusicEnable = true;
			currentSprite.sprite = musicOnSprite;
		}
	}

	#endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour 
{
	[SerializeField] private float fillAmount; // unserialize later
	[SerializeField] private float lerpSpeed;
	[SerializeField] private Image content; 
	[SerializeField] private Image lerpingBar;
	[SerializeField] private Text valueText;
	[SerializeField] Color fullColor;
	[SerializeField] Color lowColor;

	public float MaxValue { get; set;}

	public float Value
	{
		set
		{
			string[] temp = valueText.text.Split(':');
			valueText.text = temp[0] + ": " + value;
			fillAmount = Map(value, 0, MaxValue, 0, 1);
		}
	}

	void Update() 
	{
		HandleBar();
	}

    private void HandleBar()
    {
        if (fillAmount != content.fillAmount || fillAmount != lerpingBar.fillAmount)
		{
			content.fillAmount = fillAmount;

			// lerp so that the red bar contents increase/decrease smoothly
        	lerpingBar.fillAmount = Mathf.Lerp(lerpingBar.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		}

		content.color = Color.Lerp(lowColor, fullColor, fillAmount);
    }

	private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}

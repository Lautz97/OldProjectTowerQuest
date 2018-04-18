using UnityEngine;
public class ReadScreenLimits : MonoBehaviour 
{

	private void Awake () 
	{
        GameObject Mcam = GameObject.FindGameObjectWithTag("MainCamera");
        PlayerPrefs.SetFloat("LowerSL", -Mcam.GetComponent<Camera>().orthographicSize);
        PlayerPrefs.SetFloat("UpperSL", Mcam.GetComponent<Camera>().orthographicSize);
        PlayerPrefs.SetFloat("LeftSL", -Mcam.GetComponent<Camera>().orthographicSize * Screen.width / Screen.height);
        PlayerPrefs.SetFloat("RightSL", Mcam.GetComponent<Camera>().orthographicSize * Screen.width / Screen.height);
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
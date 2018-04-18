using UnityEngine;
public class AddPauseButton : MonoBehaviour 
{
    [SerializeField]
    GameObject PB;
    [SerializeField]
    float offset = -0.5f;
    public void AddButton(float XSL, float YSL)
    {
        GameObject npb = Instantiate(PB, new Vector3(XSL + offset, YSL + offset, 0), Quaternion.identity);
        GameObject Mcam = GameObject.FindGameObjectWithTag("MainCamera");
        npb.transform.parent = Mcam.transform;
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
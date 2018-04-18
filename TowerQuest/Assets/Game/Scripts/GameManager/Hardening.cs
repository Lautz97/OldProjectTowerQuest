using UnityEngine;
public class Hardening : MonoBehaviour 
{
    
    public void HardeningMechs(float lowYSpawnLimit, float highYSpawnLimit)
    {
        float offset = 0.01f;
        float memory = 0;
        if (highYSpawnLimit < 5)
        {
            if (lowYSpawnLimit < highYSpawnLimit)
            {
                gameObject.GetComponent<PlatSpawn>().SetYSpawnLimits(lowYSpawnLimit + offset, highYSpawnLimit);
                memory += offset;
            }
            if (lowYSpawnLimit >= highYSpawnLimit)
            {
                gameObject.GetComponent<PlatSpawn>().SetYSpawnLimits(lowYSpawnLimit - memory, highYSpawnLimit + offset);
                memory = 0;
            }
        }
    }

}

/*
*Copyright(c) 
*Davide "Lautz" Lauterio
*/
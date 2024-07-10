using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PowerUps : MonoBehaviour
{
    [Tooltip("")] public PowerUpType currentPowerUp = PowerUpType.none;
   


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            currentPowerUp = other.gameObject.GetComponent<PowerUPSelector>().powerUpType;
        }
    }
}
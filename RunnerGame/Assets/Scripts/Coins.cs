using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    //Bu yorum deneme amaçlıdır. Github testi içindir.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(100* Time.deltaTime, 0, 0);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {

            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            PlayerManager.numberOfCoins += 1;
            Debug.Log("Coins Number" + PlayerManager.numberOfCoins);
            Destroy(gameObject);
        }
    }
}

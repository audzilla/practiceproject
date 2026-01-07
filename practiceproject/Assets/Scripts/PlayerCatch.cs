using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    public GameManager gameManager;
    
    void OnTriggerEnter(Collider other)
    {
        Catch thisObject = other.gameObject.GetComponent<Catch>();
        int Score = thisObject.GetScore(); 
        gameManager.IncrementScore(Score);        
    }
}

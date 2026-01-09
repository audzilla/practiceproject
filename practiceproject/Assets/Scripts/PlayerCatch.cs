using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Catch>() is Catch thisObject)
        {
            int Score = thisObject.GetScore();
            gameManager.IncrementScore(Score);
        }
    }
}

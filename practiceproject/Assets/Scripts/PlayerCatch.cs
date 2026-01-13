using UnityEngine;
using UnityEngine.Rendering;
using static Unity.VisualScripting.Member;

public class PlayerCatch : MonoBehaviour
{
    public GameManager gameManager;
    private AudioClip onCatch;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Catch>() is Catch thisObject && gameManager.GameActive == true)
        {
            int Score = thisObject.GetScore();
            gameManager.IncrementScore(Score);
            PlaySound(other);            
        }
    }

    void PlaySound(Collider other)
    {
        //play whichever sound is set on the caught object
        Catch caughtObject = other.GetComponent<Catch>();
        onCatch = caughtObject.PlayOnCatch;
        AudioSource.PlayClipAtPoint(onCatch, transform.position, 1.0f);
    }
}

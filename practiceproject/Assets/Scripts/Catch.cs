using Unity.VisualScripting;
using UnityEngine;


public class Catch : MonoBehaviour
{
    [SerializeField] private int score;
    public AudioClip PlayOnCatch;

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    public int GetScore()
    {
        return score; 
    } 


}

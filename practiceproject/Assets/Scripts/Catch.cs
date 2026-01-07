using Unity.VisualScripting;
using UnityEngine;


public class Catch : MonoBehaviour
{
    [SerializeField] private int score;

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, .01f);
    }

    public int GetScore()
    {
        return score; 
    } 


}

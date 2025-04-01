using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Animator anim;

    public int points = 1;  // How many points this coin is worth
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("CoinPop");
            FindObjectOfType<ScoreManager>().AddPoint();
            Debug.Log("Player collected the item!");
            Destroy(gameObject, 0.25f);
        }
    }

}

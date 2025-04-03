using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Animator anim;
    public AudioClip pickupSound;
    private AudioSource audioSource;


    public int points = 1;  // How many points this coin is worth
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("CoinPop");
            FindObjectOfType<ScoreManager>().AddPoint();
            Debug.Log("Player collected the item!");
            audioSource.PlayOneShot(pickupSound);
            Destroy(gameObject, 0.25f);
        }
    }

}

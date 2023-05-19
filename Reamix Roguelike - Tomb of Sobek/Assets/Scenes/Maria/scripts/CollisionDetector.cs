using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
     void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("ball"))
        {
            Debug.Log("La boule a collisionné avec l'objet !");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}

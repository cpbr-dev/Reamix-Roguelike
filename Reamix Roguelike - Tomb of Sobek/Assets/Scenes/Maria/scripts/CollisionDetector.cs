using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    // private void OnCollisionEnter(Collision collision)
    // {
        
    //     if (collision.gameObject.CompareTag("ball"))
    //     {
        
    //         Debug.Log("La boule a collisionné avec l'objet !");
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //     }
    // }

     void OnCollisionEnter(Collision collision)
    {
        // Vérifiez si l'objet avec lequel la boule est entrée en collision a l'étiquette "Obstacle"
        Debug.Log("La boule a collisionné avec l'objet !");
        if (collision.gameObject.CompareTag("ball"))
        {
            Debug.Log("La boule a collisionné avec l'objet !");
            // Arrêtez la scène en chargeant une nouvelle scène
            SceneManager.LoadScene("GameOverScene");
        }
    }
}

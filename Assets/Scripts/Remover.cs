using UnityEngine;

public class Remover : MonoBehaviour
{
    [SerializeField] private string filterTag;
    private int removedEnemies = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (filterTag == null || filterTag == "")
        {
            Destroy(collision.gameObject);
        }
        else
        {
            if (collision.gameObject.tag == filterTag)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

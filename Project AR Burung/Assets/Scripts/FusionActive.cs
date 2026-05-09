using UnityEngine;

public class FusionActive : MonoBehaviour
{
    public GameObject fusionResult; // Prefab hasil fusion
    public Transform spawnPoint; // Posisi untuk objek hasil fusion
    public string TagBenda;

void OnTriggerEnter(Collider other)
{
    // Cek apakah objek yang bertabrakan adalah objek yang bisa difusion
    if (other.CompareTag(TagBenda))
    {
        Destroy(other.gameObject);
        Destroy(this.gameObject);

        // Spawn objek baru sebagai hasil fusion
        Instantiate(fusionResult, spawnPoint.position, spawnPoint.rotation);
    }
}
}

using UnityEngine;

public class Respawn : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("We've collided!");
        Player p = other.GetComponent<Player>();
        if (p != null)
            player.transform.position = respawnPoint.transform.position;
    }
}

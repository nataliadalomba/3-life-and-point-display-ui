using Unity.VisualScripting;
using UnityEngine;

public class Respawn : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other) {
        Player p = other.GetComponent<Player>();
        if (p != null) {
            FindObjectOfType<GridMovement>().stopMovePlayer();
            player.transform.position = respawnPoint.transform.position;
            ScoreManager.instance.SubtractLife();
        if (ScoreManager.instance.PlayerDeath()) return;
            FindObjectOfType<GridMovement>().startMovePlayer();
        }
    }
}

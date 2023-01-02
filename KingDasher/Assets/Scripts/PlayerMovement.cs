using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody _player;
    public int _strenght;
    [Space]
    public int _deaths;
    public int _deathLimit = 5;
    [Space]
    public GameManager _manager;

    public void Update() {
        if(this.gameObject.transform.position.y > -5){ // The checker if the Player fell
            if(Input.GetKeyDown(KeyCode.A)) { _player.AddForce(-Vector3.left * _strenght, ForceMode.Impulse); }
            if(Input.GetKeyDown(KeyCode.D)) { _player.AddForce(-Vector3.right * _strenght, ForceMode.Impulse); }
        } else {
            _deaths++;
            this.transform.position = new Vector3(0, 5, 2.68f);
            this.transform.rotation = Quaternion.identity;
            _player.velocity = new Vector3(0, 0, 0);
        }

        if(_deaths == _deathLimit){ // Triggers the Death Panel.
            _manager.Died("Died");
        }
    }
}

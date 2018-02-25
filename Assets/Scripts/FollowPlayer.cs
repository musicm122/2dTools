using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    GameObject Player;


    Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        offset = transform.position - Player.transform.position;

    }

    private void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}

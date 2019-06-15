using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float coinSpeed = 2.0f;
    public GameObject spawnPrefab;
    // Start is called before the first frame update
    void Start()
    {
       Invoke("DropSpawn", 1.0f); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(coinSpeed * Time.deltaTime, 0, 0);
        if (Mathf.Abs(transform.position.x) > 7.0f) {
            coinSpeed *= -1.0f;
        }
    }
    
    void DropSpawn()
    {
        GameObject spawn = Instantiate<GameObject>(spawnPrefab);
        Invoke("DropSpawn", 0.5f);
        spawn.transform.position = transform.position;
    }
    // private void OnCollisionEnter2d(Collision2D collision){
    //     if (collision.gameObject.name == "Bounds"){
    //         coinSpeed*= -1.0f;
    //     }
    // }
}

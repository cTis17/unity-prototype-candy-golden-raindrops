using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoundsBehavior : MonoBehaviour
{
    
    public int score;
    private List<GameObject> basketList;
    public GameObject basketPrefab;
    private AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        basketList = new List<GameObject>();
        float bottomEdge = transform.position.y + .5f;
        for (int i = 3; i >0; i--)
        {
            GameObject basket = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = basket.transform.position;
            pos.y = bottomEdge + (i * 0.5f);
            basket.transform.position = pos;
            basketList.Add(basket);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spawn")
        {
            audioSources[1].Play();
            int bottomBasket = basketList.Count -1;
            if (bottomBasket > -1)
            {
                Destroy(basketList [bottomBasket]);
                basketList.RemoveAt(bottomBasket);
            }
            GameObject[] spawnArray = GameObject.FindGameObjectsWithTag("spawn");
            foreach (GameObject spawn in spawnArray)
            {
                Destroy(spawn);
            }

            if (bottomBasket < 1)
            {
                Destroy(GameObject.Find("Coin"));
                Invoke("RestartScene", 3.0f);
            }
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene("MainScene");
    }


    public void IncrementScore()
    {
        score++;
        audioSources[0].Play();
        GameObject.Find("ScoreOutput").GetComponent<Text>().text = score.ToString();
    }

}

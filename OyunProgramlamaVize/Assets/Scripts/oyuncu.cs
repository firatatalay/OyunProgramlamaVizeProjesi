using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class oyuncu : MonoBehaviour
{
    public string axisName = "hareket";
    public float moveSpeed = 10f;
    public Rigidbody2D bombPrefab;
    public Transform bombSpawn;
    [Range(1f, 50000f)]
    public float bombSpeed = 2000f;
    public Transform hedef;
    public Text scoreText;
    public int maxScore;
    public int Score { get; private set; }

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/LastGame.dat";
        if (File.Exists(path))
        {
            GameData gameData = SaveLoadManager.Load(path);
            maxScore = gameData.score;
            if (PlayerPrefs.GetString("lastGame", false.ToString()) == true.ToString())
            {
                Score = maxScore;
                scoreText.text = Score.ToString();
                transform.position = new Vector2(transform.position.x, gameData.yKonumu);
                PlayerPrefs.SetString("lastGame", false.ToString());
            }
        }

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveAxis = Input.GetAxis(axisName) * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveAxis, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var bomb = Instantiate(bombPrefab, bombSpawn.position, Quaternion.identity);
        bomb.AddForce(new Vector2(0, 1) * bombSpeed);
        Destroy(bomb.gameObject, 2f);
    }

    public void SkorYap()
    {
        Score++;
        scoreText.text = Score.ToString();

        if (Score % 5 == 0)
            transform.position += transform.up;

        if ((hedef.position.y - transform.position.y) < 3f)
            transform.position = new Vector2(0, -4.47f);

        if (maxScore < Score)
        {
            maxScore = Score;
            Debug.Log("H: " + maxScore.ToString());
            Debug.Log("S: " + Score.ToString());
            GameData gameData = new GameData();
            gameData.score = maxScore;
            gameData.yKonumu = transform.position.y;
            SaveLoadManager.Save("Assets/LastGame.dat", gameData);
        }

    }


  


}

[Serializable]
public class GameData
{
    public int score;
    public float yKonumu;
}

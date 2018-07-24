using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    enum State
    {
        Ready,
        Play,
        GameOver
    }

    State state;

    public BubbleController bubble;
    public GameObject blocks;
	// Use this for initialization
	void Start () {
        Ready();
	}
	
	// Update is called once per frame
	void Update () {
		
        switch (state)
        {
            case State.Ready:
                //タッチしたらゲームスタート
                if (Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                }
                break;
            case State.Play:
                //バブルが死んだらゲームオーバー
                if(bubble.IsDead())
                {
                    GameOver();
                }
                break;

            case State.GameOver:
                if (Input.GetButtonDown("Fire1"))
                {
                    Reload();
                }
                break;
        }
	}

    void Reload()
    {
        SceneManager.LoadScene("Main");
    }

    void Ready()
    {
        state = State.Ready;
        blocks.SetActive(false);
    }

    void GameStart()
    {
        state = State.Play;
        blocks.SetActive(true);
    }

    void GameOver()
    {
        state = State.GameOver;

        ScrollObjects[] scrollObjects = GameObject.FindObjectsOfType<ScrollObjects>();

        foreach (ScrollObjects scroll in scrollObjects)
        {
            scroll.enabled = false;
        }
    }//今回だと配列scrollObjectsをforeachで一つ一つ取得し、
     //scroll変数に格納して44行目でscroll.enabled = falseとすることで、
     //ScrollObjectsコンポーネントを機能させないようにしています。
     //それを配列scrollObjectsの個数分繰り返します
}

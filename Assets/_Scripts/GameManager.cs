using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    [SerializeField] GameState gameState;

    public GameState GameState { get => gameState; set => gameState = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGameState(GameState state)
    {
        gameState = state;
        switch (state)
        {
            case GameState.MainMenu:
                break;
            case GameState.Pause:
                break;
            case GameState.Attack:
                break;
            case GameState.Wait:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
        }
    }
}


public enum GameState
{
    MainMenu,
    Pause,
    Attack,
    Wait,
    Win,
    Lose
}
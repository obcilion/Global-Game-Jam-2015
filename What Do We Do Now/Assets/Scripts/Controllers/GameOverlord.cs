using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GameOverlord : MonoBehaviour
{
    public enum GameState
    {
        Planning = 0,
        Execution
    }

    private ShapeeHerder _shapeeHerder;
    [SerializeField] private List<GameObject> _shapees;

    public GameState CurrentGameState { get; private set; }

    public void MoveShapees()
    {
        if (CurrentGameState == GameState.Execution)
        {
            return;
        }
        CurrentGameState = GameState.Execution;
        _shapeeHerder.PerformAllActions(ShapeesDoneMoving);
    }

    public void SpawnShapees()
    {
        //_shapeeHerder.ShapeesInScene.Add(Instantiate());
    }

    private void ShapeesDoneMoving()
    {
        CurrentGameState = GameState.Planning;
    }

    // Use this for initialization
    void Awake()
    {
        _shapeeHerder = new ShapeeHerder();
        _shapeeHerder.Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

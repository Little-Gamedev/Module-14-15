using UnityEngine;

public class Initializator : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _player.NewGame();

    }
}

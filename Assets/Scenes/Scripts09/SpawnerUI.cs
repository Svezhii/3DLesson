using TMPro;
using UnityEngine;

public class SpawnerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalCubesText;
    [SerializeField] private TextMeshProUGUI totalBombsText;
    [SerializeField] private TextMeshProUGUI activeObjectsText;

    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombSpawner _bombSpawner;

    private int _activeCount;

    private void Start()
    {
        totalCubesText.text = $"Всего заспавнено кубов - 0";
        totalBombsText.text = $"Всего заспавнено бомб - 0";
        activeObjectsText.text = $"Всего активных объектов - 0";
    }

    private void Update()
    {
        activeObjectsText.text = $"Всего активных объектов - {_cubeSpawner.ActiveObjects + _bombSpawner.ActiveObjects}";
    }

    private void OnEnable()
    {
        _cubeSpawner.OnTotalSpawnedChanged += UpdateTotalCubesText;
        _bombSpawner.OnTotalSpawnedChanged += UpdateTotalBombsText;
    }

    private void OnDisable()
    {
        _cubeSpawner.OnTotalSpawnedChanged -= UpdateTotalCubesText;
        _bombSpawner.OnTotalSpawnedChanged -= UpdateTotalBombsText;
    }

    private void UpdateTotalCubesText(int count)
    {
        totalCubesText.text = $"Всего заспавнено кубов - {count}";
    }

    private void UpdateTotalBombsText(int count)
    {
        totalBombsText.text = $"Всего заспавнено бомб - {count}";
    }
}
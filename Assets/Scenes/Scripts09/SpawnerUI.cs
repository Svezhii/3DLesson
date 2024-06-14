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
        totalCubesText.text = $"����� ���������� ����� - 0";
        totalBombsText.text = $"����� ���������� ���� - 0";
        activeObjectsText.text = $"����� �������� �������� - 0";
    }

    private void Update()
    {
        activeObjectsText.text = $"����� �������� �������� - {_cubeSpawner.ActiveObjects + _bombSpawner.ActiveObjects}";
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
        totalCubesText.text = $"����� ���������� ����� - {count}";
    }

    private void UpdateTotalBombsText(int count)
    {
        totalBombsText.text = $"����� ���������� ���� - {count}";
    }
}
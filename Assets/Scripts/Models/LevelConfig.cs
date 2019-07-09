using System.Collections.Generic;

public class LevelConfig {

    public int minTouristsPerWave;
    public int maxTouristsPerWave;
    public int minEnemiesPerWave;
    public int maxEnemiesPerWave;
    public int timeBetweenWaves;
    public int timeBetweenEnemyWaves;
    public float touristSpanSpeed;
    public int touristSpeed;
    public int enemyHealth;
    public int enemySpeed;

    public LevelConfig() { }
    public LevelConfig(
        int _minTouristsPerWave,
        int _maxTouristsPerWave,
        int _minEnemiesPerWave,
        int _maxEnemiesPerWave,
        int _timeBetweenWaves,
        int _timeBetweenEnemyWaves,
        float _touristSpanSpeed,
        int _touristSpeed,
        int _enemyHealth,
        int _enemySpeed
    ) {
        minTouristsPerWave = _minTouristsPerWave;
        maxTouristsPerWave = _maxTouristsPerWave;
        minEnemiesPerWave = _minEnemiesPerWave;
        maxEnemiesPerWave = _maxEnemiesPerWave;
        timeBetweenWaves = _timeBetweenWaves;
        timeBetweenEnemyWaves = _timeBetweenEnemyWaves;
        touristSpanSpeed = _touristSpanSpeed;
        touristSpeed = _touristSpeed;
        enemyHealth = _enemyHealth;
        enemySpeed = _enemySpeed;
    }
}

using UnityEngine;
/// <summary>
/// This script only needs to be in the first object in your scene and is an alternative way to setup prefabs in the inspector, rather than code.
/// </summary>
public class SpawningPoolScript : MonoBehaviour {
    private static SpawningPoolScript instance;
    public static SpawningPoolScript Instance { get { return instance; } }

    private bool awake;

    [System.Serializable]
    public struct SpawningPoolEntry {
        public string Key;
        public GameObject Prefab;
    }

    [Tooltip("List of prefabs to add to the spawning pool upon start")]
    public SpawningPoolEntry[] Prefabs;

    [Tooltip("Whether to return spawned objects to cache on level load.")]
    public bool ReturnToCacheOnLevelLoad = true;

    private void SceneWasLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode) {
        if (ReturnToCacheOnLevelLoad) {
            SpawningPool.RecycleActiveObjects();
        }
    }

    private void Awake() {
        if (awake) {
            return;
        }
        else if (instance == null) {
            awake = true;
            instance = this;
            DontDestroyOnLoad(this);
            if (Prefabs != null) {
                foreach (var prefab in Prefabs) {
                    SpawningPool.AddPrefab(prefab.Key, prefab.Prefab);
                }
            }
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += SceneWasLoaded;
        }
        else {
            Object.Destroy(gameObject);
        }
    }
}
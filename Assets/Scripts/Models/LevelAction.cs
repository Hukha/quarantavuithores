using System.Collections.Generic;

public class LevelAction {
    public List<Tourist> touristsToSpawn;
    public List<Enemy> enemiesToSpawn;

    public LevelAction (List<Tourist> _touristsToSpawn, List<Enemy> _enemiesToSpawn) {
        touristsToSpawn = _touristsToSpawn;
        enemiesToSpawn = _enemiesToSpawn;
    }
}
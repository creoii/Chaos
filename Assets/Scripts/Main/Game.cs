using UnityEngine;

public class Game : MonoBehaviour
{
    public static GameSettings settings;
    public StatusEffectBuilder statusEffectBuilder = new StatusEffectBuilder();
    public AttackBuilder attackBuilder = new AttackBuilder();
    public ItemBuilder itemBuilder = new ItemBuilder();
    public TransitionBuilder transitionBuilder = new TransitionBuilder();
    public MovementBuilder movementBuilder = new MovementBuilder();
    public PhaseBuilder phaseBuilder = new PhaseBuilder();
    public EnemyBuilder enemyBuilder = new EnemyBuilder();
    public DungeonBuilder dungeonBuilder = new DungeonBuilder();
    public RoomBuilder roomBuilder = new RoomBuilder();
    public TileProviderBuilder tileProviderBuilder = new TileProviderBuilder();

    private void Awake()
    {
        settings = new GameSettings();
        statusEffectBuilder.ReadAndStoreData();
        attackBuilder.ReadAndStoreData();
        itemBuilder.ReadAndStoreData();
        transitionBuilder.ReadAndStoreData();
        movementBuilder.ReadAndStoreData();
        phaseBuilder.ReadAndStoreData();
        enemyBuilder.ReadAndStoreData();
        dungeonBuilder.ReadAndStoreData();
        roomBuilder.ReadAndStoreData();
        tileProviderBuilder.ReadAndStoreData();
    }
}

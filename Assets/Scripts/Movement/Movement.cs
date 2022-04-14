using System;
using UnityEngine;

[Serializable]
public class Movement
{
    public string name;
    public string type;
    public string target = "self";
    public float speed;
    public float orbitDistance;
    public float startSpeed;
    public PositionData3d orbitStartTranslation;
    public float wanderRange;
    public float minChangeThreshold;
    public float maxChangeThreshold;

    private Vector3 targetPos;
    private Vector3 wanderTarget;
    private bool atTarget = true;

    public Movement(string name, string type, string target, float speed, float orbitDistance, float startSpeed, PositionData3d orbitStartTranslation, float wanderRange, float minChangeThreshold, float maxChangeThreshold)
    {
        this.name = name;
        this.type = type;
        this.target = target;
        this.speed = speed;
        this.orbitDistance = orbitDistance;
        this.startSpeed = startSpeed;
        this.orbitStartTranslation = orbitStartTranslation;
        this.wanderRange = wanderRange;
        this.minChangeThreshold = minChangeThreshold;
        this.maxChangeThreshold = maxChangeThreshold;
    }

    public static Movement Override(Movement one, Movement two)
    {
        return new Movement(
            two.name == null ? one.name : two.name,
            two.type == null ? one.type : two.type,
            two.target == null ? one.target : two.target,
            two.speed == 0 ? one.speed : two.speed,
            two.orbitDistance == 0 ? one.orbitDistance : two.orbitDistance,
            two.startSpeed == 0 ? one.startSpeed : two.startSpeed,
            two.orbitStartTranslation == null ? one.orbitStartTranslation : PositionData3d.Override(one.orbitStartTranslation, two.orbitStartTranslation),
            two.wanderRange == 0 ? one.wanderRange : two.wanderRange,
            two.minChangeThreshold == 0 ? one.minChangeThreshold : two.minChangeThreshold,
            two.maxChangeThreshold == 0 ? one.maxChangeThreshold : two.maxChangeThreshold
        );
    }

    public void Start(Enemy enemy, GameObject character)
    {
        targetPos = enemy.GetPosition();
        if (target.Equals("origin")) targetPos = enemy.GetOrigin();
        else if (target.Equals("player")) targetPos = character.transform.position;
        else if (target.Equals("mouse")) targetPos = MouseUtil.GetMouseWorldPos();
    }

    public void Run(Enemy enemy, GameObject character)
    {
        switch (EnumUtil.Parse<MovementType>(type))
        {
            case MovementType.Wander:
                RunWander(enemy, targetPos);
                return;
            case MovementType.Orbit:
                RunOrbit(enemy, targetPos);
                return;
            case MovementType.Follow:
                RunFollow(enemy, character);
                return;
        }
    }

    void RunWander(Enemy enemy, Vector3 center)
    {
        if (atTarget)
        {
            wanderTarget = VectorUtil.GetRandomPosition(new Vector3(center.x - wanderRange, center.y - wanderRange), new Vector3(center.x + wanderRange, center.y + wanderRange));
            atTarget = false;
        }
        else
        {
            if (Vector3.Distance(enemy.GetPosition(), wanderTarget) >= UnityEngine.Random.Range(minChangeThreshold, maxChangeThreshold))
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.GetPosition(), wanderTarget, speed * Time.deltaTime);
            }
            else atTarget = true;
        }
    }

    void RunOrbit(Enemy enemy, Vector3 center)
    {
        if (Vector3.Distance(enemy.GetPosition(), orbitStartTranslation.GetAsVector3() * orbitDistance) >= orbitDistance)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.GetPosition(), orbitStartTranslation.GetAsVector3() * orbitDistance, startSpeed * Time.deltaTime);
        }
        //else entity.transform.RotateAround(center, -Vector3.forward, speed * Time.deltaTime);
    }

    void RunFollow(Enemy enemy, GameObject target)
    {
        if (Vector3.Distance(enemy.GetPosition(), target.transform.position) >= UnityEngine.Random.Range(minChangeThreshold, maxChangeThreshold))
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.GetPosition(), target.transform.position, speed * Time.deltaTime);
        }
    }
}

using UnityEngine;

public class BlackholeSkill : Skill
{
    [SerializeField] int amountOfAttacks;
    [SerializeField] float cloneAttackCooldown;
    [SerializeField] float blackholeDuration;
    [Space]
    [SerializeField] float maxSize;
    [SerializeField] float growSpeed;
    [SerializeField] float shrinkSpeed;
    [SerializeField] private GameObject blackholePrefab;

    BlackholeSkillController controller;

    public override bool CanUseSkill()
    {
        return base.CanUseSkill();
    }

    public override void UseSkill()
    {
        base.UseSkill();

        GameObject blackhole = Instantiate(blackholePrefab, player.transform.position, Quaternion.identity);

        controller = blackhole.GetComponent<BlackholeSkillController>();
        controller.SetupBlackhole(maxSize, growSpeed, shrinkSpeed, amountOfAttacks, cloneAttackCooldown, blackholeDuration);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public bool SkillCompleted()
    {
        if (!controller)
            return false;

        if (controller.playerCanExitState)
        {
            controller = null;
            return true;
        }

        return false;
    }

    public float GetBlackholeRadius()
    {
        return maxSize / 2;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class BlackholeSkill : Skill
{
    [SerializeField] private UISkillTreeSlot blackHoleUnlockButton;
    public bool blackholeUnlocked { get; private set; }
    [SerializeField] int amountOfAttacks;
    [SerializeField] float cloneAttackCooldown;
    [SerializeField] float blackholeDuration;
    [Space]
    [SerializeField] float maxSize;
    [SerializeField] float growSpeed;
    [SerializeField] float shrinkSpeed;
    [SerializeField] private GameObject blackholePrefab;

    BlackholeSkillController controller;

    private void UnlockBlackhole()
    {
        if (blackHoleUnlockButton.unlocked)
            blackholeUnlocked = true;
    }

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

        blackHoleUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockBlackhole);
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

    protected override void CheckUnlock()
    {
       UnlockBlackhole();
    }
}

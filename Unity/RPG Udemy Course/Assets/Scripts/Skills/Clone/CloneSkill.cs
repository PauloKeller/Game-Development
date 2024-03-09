using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneSkill : Skill
{
    [Header("Clone Info")]
    [SerializeField] private float attackMultiplier;
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float cloneDuration;
    [Space]

    [Header("Clone attack")]
    [SerializeField] private UISkillTreeSlot cloneAttackUnlockButton;
    [SerializeField] private float cloneAttackMultiplier;
    [SerializeField] private bool canAttack;

    [Header("Aggressive clone")]
    [SerializeField] private UISkillTreeSlot aggressiveCloneUnlockButton;
    [SerializeField] private float aggressiveCloneAttackMultiplier;
    public bool canApplyOnHitEffect { get; private set; }

    [Header("Multiple Clone")]
    [SerializeField] private UISkillTreeSlot multipleUnlockButton;
    [SerializeField] private float multipleCloneAttackMultiplier;
    [SerializeField] private bool canDuplicateClone;
    [SerializeField] private float chanceToDuplicate;

    [Header("Crystal isntead of clone")]
    [SerializeField] private UISkillTreeSlot crystalInsteadUnlockButton;
    public bool crystalInsteadOfClone;

    protected override void Start()
    {
        base.Start();

        cloneAttackUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockCloneAttack);
        aggressiveCloneUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockAggressiveClone);
        multipleUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockMultiClone);
        crystalInsteadUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockCrystalInstead);
    }

    protected override void CheckUnlock()
    {
        UnlockCloneAttack();
        UnlockAggressiveClone();
        UnlockMultiClone();
        UnlockCrystalInstead();
    }

    #region Unlock region
    private void UnlockCloneAttack()
    {
        if (cloneAttackUnlockButton.unlocked)
        { 
            canAttack = true;
            attackMultiplier = cloneAttackMultiplier;
        }
    }

    private void UnlockAggressiveClone()
    {
        if (aggressiveCloneUnlockButton.unlocked)
        {
            canApplyOnHitEffect = true;
            attackMultiplier = aggressiveCloneAttackMultiplier;
        }
            
    }

    private void UnlockMultiClone()
    {
        if (multipleUnlockButton.unlocked)
        {
            canDuplicateClone = true;
            attackMultiplier = multipleCloneAttackMultiplier;
        }
    }

    private void UnlockCrystalInstead()
    {
        if (crystalInsteadUnlockButton.unlocked)
        {
            crystalInsteadOfClone = true;
        }
    }

    #endregion

    public void CreateClone(Transform clonePosition, Vector3 offset) 
    { 
        if (crystalInsteadOfClone) 
        {
            SkillManager.instance.crystal.CreateCrystal();
            return;
        }

        GameObject newClone = Instantiate(clonePrefab);
        newClone.GetComponent<CloneSkillController>()
            .SetupClone(
            clonePosition, 
            cloneDuration, 
            canAttack, 
            offset, 
            FindClosestEnemy(clonePosition.transform), 
            canDuplicateClone, 
            chanceToDuplicate, 
            player, 
            attackMultiplier);
    }
    public void CreateCloneWithDelay(Transform enemyTransform)
    {
        StartCoroutine(CloneDelayCorotine(enemyTransform, new Vector3(2 * player.facingDir, 0)));
    }

    private IEnumerator CloneDelayCorotine(Transform enemyTransform, Vector3 offSet)
    { 
        yield return new WaitForSeconds(.4f);
            
        CreateClone(enemyTransform, offSet);
    }
}

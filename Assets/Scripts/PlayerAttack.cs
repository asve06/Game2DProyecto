using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform ataquePoint;
    [SerializeField] private GameObject[] objetoAtaque;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        objetoAtaque[FindFireball()].transform.position = ataquePoint.position;
        objetoAtaque[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireball()
    {
        for (int i = 0; i < objetoAtaque.Length; i++)
        {
            if (!objetoAtaque[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
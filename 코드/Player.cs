using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    #region ���� ���� ��������
    [SerializeField]
    private Player_Stat player_stat; // �÷��̾� ���� ����

    public Sprite PlayerSprite => player_stat.stat[level].sprite;
    public float Speed         => player_stat.stat[level].Speed;
    public float Weight        => player_stat.stat[level].Weight;
    public float Length        => player_stat.stat[level].Length;
    public float StCharge      => player_stat.stat[level].StCharge;
    public float StDecrease    => player_stat.stat[level].StDecrease;
    public float Dash          => player_stat.stat[level].Dash;
    public float DashSt        => player_stat.stat[level].DashSt;
    public float Eyesight      => player_stat.stat[level].Eyesight;
    #endregion
    //���� ����
    public int level = 0;
    //�̵� ����
    private float horizontal;
    private bool isFacingRight = true;
    private bool canDash = true;
    private bool isDashing;
    private float DashingTime = 0.2f;
    private float DashingCooldown = 1f;
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private TrailRenderer tr;
    //�÷��̾� ���׹̳� ��
    public Image StaminaBar;
    public float MaxSt = 100;
    public float Stamina = 0;
    //���� ��Ÿ��
    public float levelTime;
    public float levelcoolTime = 1.5f;
    //�÷��̾� ü��
    public float Hp = 0;
    public float MaxHp = 10;

    private void Start()
    {
        Stamina = MaxSt;
        Hp = MaxHp;
    }


    private void Update()
    {
        #region �÷��̾� �̵�
        if(isDashing)
        {
            return;
        }
        
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetKey(KeyCode.Space) && canDash)
        {
            StartCoroutine(Player_Dash());
        }
        Flip();
        #endregion

        #region ���� ���ϱ�
        // ������Ʈ�� ��ġ ���ϱ�
        Vector3 mPosition = Input.mousePosition; // ���콺�� ��ġ (x, y)
        Vector3 oPosition = transform.position; // �÷��̾��� ��ġ
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition); // (x,y,z)
        //���� ���ϱ�
        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;
        float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        //ȸ��
        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
        #endregion

        #region ������
        levelTime = levelTime + Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Level_Up();
        }

        if(Input.GetMouseButtonDown(1))
        {
            Level_Down();
        }
        #endregion

        Player_Stamina();
    }

    private void FixedUpdate()
    {
        if(isDashing) 
        { 
            return; 
        }

        rbody.velocity = new Vector2 (horizontal * Speed, rbody.velocity.y);
    }


    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
    private IEnumerator Player_Dash()
    {
        // ���׹̳ʰ� �뽬 ���׹̳ʺ��� ������ �뽬 �ߵ�.
        if (Stamina - DashSt > 0)
        {
            Stamina -= DashSt;
            StaminaBar.fillAmount = Stamina / 100f;
            canDash = false;
            isDashing = true;
            float originalGravity = rbody.gravityScale;
            rbody.gravityScale = 0f;
            rbody.velocity = new Vector2(transform.localScale.x * Dash, 0f);
            tr.emitting = true;
            yield return new WaitForSeconds(DashingTime);
            tr.emitting = false;
            rbody.gravityScale = originalGravity;
            isDashing = false;
            yield return new WaitForSeconds(DashingCooldown);
            canDash = true;
        }
    }

    private void Player_Stamina()
    {
        // ���� 1 �̻��� �� ���׹̳� ���� 0���� ���Ҵ� �ȵǰ� ��.
        if(level > 0 && Stamina - StDecrease > 0)
        {
            Stamina += StDecrease * Time.deltaTime;
            StaminaBar.fillAmount = Stamina /100f;
        }
        // ������ 0 �϶� ���׹̳� ȸ�� MaxSt�̻��� �ȵǰ� ��.
        if(level == 0)
        {
            if(Stamina + StCharge < MaxSt)
            {
                Stamina += StCharge * Time.deltaTime;
                StaminaBar.fillAmount = Stamina / 100f;
            }
        }
        // ���׹̳� 0�̸� ���� 0���� ���缭 ���� ũ���
        if (Stamina <= 0)
        {
            level = 0;
            levelTime = 0;
            transform.localScale = new Vector3(Length, 1, 1);
        }
    }

    private void Level_Up()
    {
        // ���� �� 3�� ��Ÿ�� ���� �ٿ�� ������ ��Ÿ��
        if(0 <= level && level <4)
        {
            if (levelTime > levelcoolTime)
            {
                level++;
                levelTime = 0;
            }
        }
        transform.localScale = new Vector3(Length, 1, 1);
    }

    private void Level_Down()
    {
        // ���� �ٿ� 3�� ��Ÿ�� �������� ������ ��Ÿ��
        if(0 < level && level <= 4)
        {
            if (levelTime > levelcoolTime)
            {
                level--;
                levelTime = 0;
            }
        }
        transform.localScale = new Vector3(Length, 1, 1);
    }
    // ������ �Դ� �� ����
    public void TakeDamage(int damage)
    {
        Hp -= damage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    #region 스탯 정보 가져오기
    [SerializeField]
    private Player_Stat player_stat; // 플레이어 스탯 정보

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
    //레벨 변수
    public int level = 0;
    //이동 변수
    private float horizontal;
    private bool isFacingRight = true;
    private bool canDash = true;
    private bool isDashing;
    private float DashingTime = 0.2f;
    private float DashingCooldown = 1f;
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private TrailRenderer tr;
    //플레이어 스테미너 바
    public Image StaminaBar;
    public float MaxSt = 100;
    public float Stamina = 0;
    //레벨 쿨타임
    public float levelTime;
    public float levelcoolTime = 1.5f;
    //플레이어 체력
    public float Hp = 0;
    public float MaxHp = 10;

    private void Start()
    {
        Stamina = MaxSt;
        Hp = MaxHp;
    }


    private void Update()
    {
        #region 플레이어 이동
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

        #region 각도 구하기
        // 오브젝트의 위치 구하기
        Vector3 mPosition = Input.mousePosition; // 마우스의 위치 (x, y)
        Vector3 oPosition = transform.position; // 플레이어의 위치
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition); // (x,y,z)
        //각도 구하기
        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;
        float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        //회전
        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
        #endregion

        #region 레벨업
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
        // 스테미너가 대쉬 스테미너보다 많으면 대쉬 발동.
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
        // 레벨 1 이상일 때 스테미너 감소 0보다 감소는 안되게 함.
        if(level > 0 && Stamina - StDecrease > 0)
        {
            Stamina += StDecrease * Time.deltaTime;
            StaminaBar.fillAmount = Stamina /100f;
        }
        // 레벨이 0 일때 스테미너 회복 MaxSt이상은 안되게 함.
        if(level == 0)
        {
            if(Stamina + StCharge < MaxSt)
            {
                Stamina += StCharge * Time.deltaTime;
                StaminaBar.fillAmount = Stamina / 100f;
            }
        }
        // 스테미너 0이면 레벨 0으로 낮춰서 원래 크기로
        if (Stamina <= 0)
        {
            level = 0;
            levelTime = 0;
            transform.localScale = new Vector3(Length, 1, 1);
        }
    }

    private void Level_Up()
    {
        // 레벨 업 3초 쿨타임 레벨 다운과 동일한 쿨타임
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
        // 레벨 다운 3초 쿨타임 레벨업과 동일한 쿨타임
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
    // 데미지 입는 것 구현
    public void TakeDamage(int damage)
    {
        Hp -= damage;
    }
}

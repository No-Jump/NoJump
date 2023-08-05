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
    public float Speed => player_stat.stat[level].Speed;
    public float Weight => player_stat.stat[level].Weight;
    public float Length => player_stat.stat[level].Length;
    public float StCharge => player_stat.stat[level].StCharge;
    public float StDecrease => player_stat.stat[level].StDecrease;
    public float Dash => player_stat.stat[level].Dash;
    public float DashSt => player_stat.stat[level].DashSt;
    public float Eyesight => player_stat.stat[level].Eyesight;
    #endregion

    #region ����
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer sprite;

    //���� ����
    public int level = 0;
    //�̵� ����
    private float horizontal;
    private bool isFacingRight = true;
    private bool canDash = true;
    private bool isDashing;
    private float DashingTime = 0.2f;
    private float DashingCooldown = 1f;
    private int DashCount = 5;
    //�÷��̾� ���׹̳� ��
    public Image StaminaBar;
    private float MaxSt = 100;
    private float Stamina = 0;
    //���� ��Ÿ��
    private float levelTime;
    private float levelcoolTime = 0.5f;
    //�÷��̾� ü��
    private float Hp = 0;
    private float MaxHp = 10;
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject Life4;
    public GameObject Life5;
    #endregion

    private void Start()
    {
        Stamina = MaxSt;
        Hp = MaxHp;
        Life1.GetComponent<Image>().enabled = true;
        Life2.GetComponent<Image>().enabled = true;
        Life3.GetComponent<Image>().enabled = true;
        Life4.GetComponent<Image>().enabled = true;
        Life5.GetComponent<Image>().enabled = true;

    }

    private void Update()
    {
        #region �÷��̾� �̵�
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.Space) && canDash)
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

        if (Input.GetMouseButtonDown(1))
        {
            Level_Down();
        }
        #endregion

        Player_Stamina();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rbody.velocity = new Vector2(horizontal * Speed, rbody.velocity.y);
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
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
        if (Stamina - DashSt > 0 && DashCount > 0)
        {
            Stamina -= DashSt;
            StaminaBar.fillAmount = Stamina / 100f;
            DashCount--;
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
        if (level > 0 && Stamina - StDecrease > 0)
        {
            Stamina += StDecrease * Time.deltaTime;
            StaminaBar.fillAmount = Stamina / 100f;
        }
        // ������ 0 �϶� ���׹̳� ȸ�� MaxSt�̻��� �ȵǰ� ��.
        if (level == 0)
        {
            if (Stamina < MaxSt)
            {
                Stamina += StCharge * Time.deltaTime;
                StaminaBar.fillAmount = Stamina / 100f;
            }
        }
        // ���׹̳� 0�̸� ���� 0���� ���缭 ���� ũ���
        if (Stamina <= 0)
        {
            level = 0;
            sprite.sprite = PlayerSprite;
            boxCollider.size = new Vector3(Length, 0.81f, 1);
        }
    }

    private void Level_Up()
    {
        // �÷��̾� ���� ü�¸�ŭ ������ �� �� ����.
        if ((Hp / 2) - 1 > level)
        {
            // ���� �� 1.5�� ��Ÿ�� ���� �ٿ�� ������ ��Ÿ��
            if (0 <= level && level < 4)
            {
                if (levelTime > levelcoolTime)
                {
                    level++;
                    levelTime = 0;
                    sprite.sprite = PlayerSprite;
                    boxCollider.size = new Vector3(Length, 0.81f, 1);
                }
            }
        }
    }

    private void Level_Down()
    {
        // ���� �ٿ� 1.5�� ��Ÿ�� �������� ������ ��Ÿ��
        if (0 < level && level <= 4)
        {
            if (levelTime > levelcoolTime)
            {
                level--;
                levelTime = 0;
                sprite.sprite = PlayerSprite;
                boxCollider.size = new Vector3(Length, 0.81f, 1);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        //������ �Դ� �� ����
        Hp -= damage;
        if (Hp == 8)
        {
            Life5.GetComponent<Image>().enabled = false;
            if (level >= 4)
            {
                level = 3;
                sprite.sprite = PlayerSprite;
                boxCollider.size = new Vector3(Length, 0.81f, 1);
            }
        }
        else if (Hp == 6)
        {
            Life5.GetComponent<Image>().enabled = false;
            Life4.GetComponent<Image>().enabled = false;
            if (level >= 3)
            {
                level = 2;
                sprite.sprite = PlayerSprite;
                boxCollider.size = new Vector3(Length, 0.81f, 1);
            }
        }
        else if (Hp == 4)
        {
            Life5.GetComponent<Image>().enabled = false;
            Life4.GetComponent<Image>().enabled = false;
            Life3.GetComponent<Image>().enabled = false;
            if (level >= 2)
            {
                level = 1;
                sprite.sprite = PlayerSprite;
                boxCollider.size = new Vector3(Length, 0.81f, 1);
            }
        }
        else if (Hp == 2)
        {
            Life5.GetComponent<Image>().enabled = false;
            Life4.GetComponent<Image>().enabled = false;
            Life3.GetComponent<Image>().enabled = false;
            Life2.GetComponent<Image>().enabled = false;
            if (level >= 1)
            {
                level = 0;
                sprite.sprite = PlayerSprite;
                boxCollider.size = new Vector3(Length, 0.81f, 1);
            }
        }
        else if (Hp == 0)
        {
            Life5.GetComponent<Image>().enabled = false;
            Life4.GetComponent<Image>().enabled = false;
            Life3.GetComponent<Image>().enabled = false;
            Life2.GetComponent<Image>().enabled = false;
            Life1.GetComponent<Image>().enabled = false;
            Debug.Log("���� ����");
        }
    }

    public void RecoverHp(int Heal)
    {
        if (Hp > 10)
        {
            Hp = 10;
        }
        else
        {
            Hp += Heal;
        }
        if (Hp == 8)
        {
            Life5.GetComponent<Image>().enabled = true;
            Life4.GetComponent<Image>().enabled = true;
            Life3.GetComponent<Image>().enabled = true;
            Life2.GetComponent<Image>().enabled = true;
        }
        else if (Hp == 6)
        {
            Life4.GetComponent<Image>().enabled = true;
            Life3.GetComponent<Image>().enabled = true;
            Life2.GetComponent<Image>().enabled = true;
        }
        else if (Hp == 4)
        {
            Life3.GetComponent<Image>().enabled = true;
            Life2.GetComponent<Image>().enabled = true;
        }
        else if (Hp == 2)
        {
            Life2.GetComponent<Image>().enabled = true;
        }
    }

    public void RecoverSt(int StHeal)
    {
        if (Stamina > 100)
        {
            Stamina = 100;
        }
        else
        {
            Stamina += StHeal;
            StaminaBar.fillAmount = Stamina / 100f;
        }

    }

    public void RecoverDash(int ReDash)
    {
        if (DashCount > 5)
        {
            DashCount = 5;
        }
        else
        {
            DashCount += ReDash;
        }
    }
}

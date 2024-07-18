using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CounterAttackManager : MonoBehaviour
{
    public TMP_Text counterKeyText;  // �����_���ȃL�[��\������
    public TMP_Text timerText;  // �U���܂ł̎��Ԃ�\������
    public TMP_Text attackText;

    public int damage = 1;  // �v���C���[�ɗ^����_���[�W

    public GameObject ammoPrefab;  // Amo�̃v���n�u
    public Transform ammoSpawnPoint;  // Amo�̐����ʒu

    private string[] counterKeys = { "A", "B", "C", "D", "E",
                                     "F", "G", "H", "I", "J",
                                     "K", "L", "M", "N", "O",
                                     "P", "Q", "R", "S", "T",
                                     "U", "V", "W", "X", "Y",
                                     "X", "1", "2", "3", "4",
                                     "5", "6", "7", "8", "9",
                                    };

    private string currentCounterKey;
    private bool isCounterActive = false;
    private float counterWindow = 5f;  // �J�E���^�[�̗P�\����
    private float timeRemaining;
    private Coroutine enemyAttackCoroutine;  // ���݂̃R���[�`�����Ǘ����邽�߂̕ϐ�

    void Start()
    {
        counterKeyText.text = "";
        timerText.text = "";
        StartEnemyAttack();  // �Q�[���J�n���ɓG�̍U�����J�n
    }

    // �G�̍U�����J�n����֐�
    public void StartEnemyAttack()
    {
        // �����̃R���[�`�������s���ł���Β�~����
        if (enemyAttackCoroutine != null)
        {
            StopCoroutine(enemyAttackCoroutine);
        }
        enemyAttackCoroutine = StartCoroutine(EnemyAttackCoroutine());
    }

    private IEnumerator EnemyAttackCoroutine()
    {
        // �����_���ȃL�[��I��ŕ\��
        currentCounterKey = counterKeys[Random.Range(0, counterKeys.Length)];
        counterKeyText.text = currentCounterKey;
        isCounterActive = true;
        timeRemaining = counterWindow;

        while (timeRemaining > 0)
        {
            timerText.text = "EnemyAttackTime: " + timeRemaining.ToString("F2") + " s";
            yield return new WaitForSeconds(0.1f);
            timeRemaining -= 0.1f;
        }

        // �J�E���^�[���������Ȃ������ꍇ
        if (isCounterActive)
        {
            InflictPlayerDamage(damage);

            // �J�E���^�[�L�[�̕\�����N���A
            counterKeyText.text = "";
            timerText.text = "";
            isCounterActive = false;
            // �ēx�G�̍U�����J�n
            StartEnemyAttack();
        }
    }

    void Update()
    {
        if (isCounterActive)
        {
            // �v���C���[���������L�[�����������`�F�b�N
            if (Input.GetKeyDown(currentCounterKey.ToLower()))
            {
                Debug.Log("�J�E���^�[����!");
                Instantiate(ammoPrefab, ammoSpawnPoint.position, ammoSpawnPoint.rotation);
                isCounterActive = false;
                counterKeyText.text = "";
                timerText.text = "";
                // �ēx�G�̍U�����J�n���Ď��Ԃ����Z�b�g
                StartEnemyAttack();
            }
            else if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("�J�E���^�[���s!");
                InflictPlayerDamage(damage);

                // �J�E���^�[�L�[�̕\�����N���A
                counterKeyText.text = "";
                timerText.text = "";
                isCounterActive = false;
                // �ēx�G�̍U�����J�n
                StartEnemyAttack();
            }
        }
    }

    private void EnemyTakeDamage(int damage)
    {
        EnemyHealthManager enemyHealth = FindObjectOfType<EnemyHealthManager>();
        if (enemyHealth != null)
        {
            enemyHealth.EnemyTakeDamage(damage);
        }
    }

    private void InflictPlayerDamage(int damage)
    {
        HealthManager playerHealth = FindObjectOfType<HealthManager>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}

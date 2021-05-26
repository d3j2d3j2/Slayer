using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private InputMovement input; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터
    private bool attacking;
    private bool attacked;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputMovement>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        attacking = false;
    }

    private void FixedUpdate()
    {
        //입력값에 따라 애니메이터의 Move 파라미터값 변경
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (input.attack > 0) attacked = true;
        else attacked = false;

        if (attacking == false && attacked == true) playerAnimator.SetBool("attack", true);
        else if (attacking == true && attacked == false) playerAnimator.SetBool("idle", true);

        attacking = attacked;
    }
}

//PlayerMovement.cs

using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMoving : MonoBehaviour {
    public float moveXSpeed = 5f; // 앞뒤 움직임의 속도
    public float moveZSpeed = 3f; // 좌우 음직임의 속도
    public float totalSpeed = 5f;
    private InputMovement inputMovement; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터
    private bool moving;
    private bool moved;

    private void Start() {
        // 사용할 컴포넌트들의 참조를 가져오기
        inputMovement = GetComponent<InputMovement>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        moving = false;
    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate() {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
        //움직임 실행
        Move();
        
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move() {
        //상대적으로 이동할 거리 계산
        Vector3 moveDistance = (inputMovement.moveZ * transform.forward + inputMovement.moveX * transform.right).normalized * totalSpeed * Time.deltaTime;
        //리지드바디를 이용해 게임 오브젝트 위치 변경
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
        //입력값에 따라 애니메이터의 Move 파라미터값 변경
        if (inputMovement.moveX != 0 || inputMovement.moveZ != 0) moved = true;
        else moved = false;

        if (moving == false && moved == true) playerAnimator.SetBool("run", true);
        else if (moving == true && moved == false) playerAnimator.SetBool("idle", true);

        moving = moved;
    }
}
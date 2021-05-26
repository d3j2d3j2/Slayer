//InputMovement.cs

using UnityEngine;

// 플레이어 캐릭터를 조작하기 위한 사용자 입력을 감지
// 감지된 입력값을 다른 컴포넌트들이 사용할 수 있도록 제공
public class InputMovement : MonoBehaviour
{
    public string zAxisName = "Vertical"; // 앞뒤 움직임을 위한 입력축 이름
    public string xAxisName = "Horizontal"; // 좌우 회전을 위한 입력축 이름
    public string attackName = "Fire1";

    // 값 할당은 내부에서만 가능
    public float moveZ { get; private set; } // 감지된 전후 입력값
    public float moveX { get; private set; } // 감지된 좌우 입력값
    public float attack { get; private set; }

    // 매프레임 사용자 입력을 감지
    private void Update()
    {
        // moveX에 관한 입력 감지
        moveX = Input.GetAxis(xAxisName);
        // moveZ에 관한 입력 감지
        moveZ = Input.GetAxis(zAxisName);

        attack = Input.GetAxis(attackName);
    }
}
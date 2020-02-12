using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRay : Singleton<MouseRay>
{
    RaycastHit MouseHis;// 마우스를 통해 RayCast

    float MaxDistance = 15.0f; // 마우스가 타일을 클릭 했을 때 무한정 멀리 있는것이 되면 안되기 때문에 설정을 해주어야함.

    bool bCheck; // 맵 에디터 모드일 땐 true 아닐 땐 false;

    public Transform target; // target은 계속 변경 가능하도록 public로 선언


    // 코루틴을 이용하여 특정 상황일 때만 작동을 하게 할 것!

    private void Update()
    {
        // 임시로 업데이트문에 넣어둠.

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mos = Input.mousePosition; // 마우스 클릭 좌표
            mos.z = Camera.main.farClipPlane;  // 카메라가 바라보고 있는 방향으로 변경

            Vector3 dir = Camera.main.ScreenToWorldPoint(mos);

            RaycastHit hit;
            Debug.DrawRay(transform.position, dir , Color.red, 0.3f);

            if (Physics.Raycast(transform.position, dir, out hit, mos.z))
            {
                //target.position = hit.point; // 타겟을 레이캐스트가 충돌된 곳으로 옮긴다.
                target.position = hit.transform.GetComponent<Transform>().position;
            }
        }
    }
}


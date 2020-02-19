using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    NONE, CREATE, END
}


public class MouseRay : Singleton<MouseRay>
{

    // float MaxDistance = 15.0f; // 마우스가 타일을 클릭 했을 때 무한정 멀리 있는것이 되면 안되기 때문에 설정을 해주어야함.

    bool bCheck; // 맵 에디터 모드일 땐 true 아닐 땐 false;

    public Transform target; // target은 계속 변경 가능하도록 public로 선언

    public Transform SubMousePointer; // Substitute MousePointer 마우스포인터 대용. 임시객체로서 

    Vector3 CurMousePostion;      // 현재 마우스위치와 비교하기 위해 만든 임시벡터

    int iState = (int)State.CREATE; // enum state를 통해 값 변경할 예정. 초기값은 NONE인 0을 준다.

    //int MaxDir = 20; // RayCast 거리값 조절 계속할 예정

    private void Start()
    {
        //// start에서 현재 마우스 위치를 넣어준다.
        Vector3 CurMousePostion = Input.mousePosition;
    }

    public void StateChange(int _iStateNumber)
    {
        switch (_iStateNumber) // iState 값에 따라서 함수 사용유무 결정.
        {
            case 0:
                iState = (int)State.NONE;
                break;
            case 1:
                iState = (int)State.CREATE;
                break;
        }
    }

    private void Update()
    {
        switch (iState) // iState 값에 따라서 함수 사용유무 결정.
        {
            case 0:
                break;
            case 1:
                ObjectDraft();
                break;
        }

    }

    #region 마우스 클릭시, 타일에 건물 설치 유무 체크

    void ObjectCreate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mos = Input.mousePosition; // 마우스 클릭 좌표
            mos.z = Camera.main.farClipPlane;  // 카메라가 바라보고 있는 방향으로 변경
            Vector3 dir = Camera.main.ScreenToWorldPoint(mos);

            RaycastHit MouseHit;// 마우스를 통해 RayCast
            Debug.DrawRay(transform.position, dir, Color.red, 0.3f);   // 디버그용도. 
            CurMousePostion = Input.mousePosition;

            //Tile에서 TileInfo 스크립트에서 TA_Object false true를 체크할 것.
            if (Physics.Raycast(transform.position, dir, out MouseHit, mos.z))
            {
                // 마우스 왼쪽 버튼 눌렀을 때
                if (Input.GetMouseButton(0))
                {
                    /// <summary>
                    /// Tile에서 TileInfo 스크립트에서 TA_Object false true를 체크할 것.
                    /// </summary>
                    if (MouseHit.transform.GetComponent<TileInfo>().TA_Object != true)
                    {
                        //target.position = hit.point; // 타겟을 레이캐스트가 충돌된 곳으로 옮긴다.
                        target.position = MouseHit.transform.GetComponent<Transform>().position; //히트한 물체의 transform을 가져오기위해 히트포지션의 컴포넌트를 불러와 이용.
                        MouseHit.transform.GetComponent<TileInfo>().TA_Object = true;
                    }
                }
                // 마우스 우측 버튼 눌렀을 때
                if (Input.GetMouseButtonUp(2))
                {

                }
            }
        }

    }

    #endregion

    #region MouseRay를 통하여 오브젝트를 미리 배치해봄.
    void ObjectDraft()
    {
        if (Input.mousePosition != CurMousePostion)
        {
            //Debug.Log("마우스 현재 좌표 : " + CurMousePostion.x + " , " + CurMousePostion.y + " , " + CurMousePostion.z);

            Vector3 mos = Input.mousePosition; // 마우스 클릭 좌표
            mos.z = Camera.main.farClipPlane;  // 카메라가 바라보고 있는 방향으로 변경
            Vector3 dir = Camera.main.ScreenToWorldPoint(mos);

            RaycastHit MouseHit;// 마우스를 통해 RayCast
            Debug.DrawRay(transform.position, dir, Color.red, 0.3f);   // 디버그용도. 
            CurMousePostion = Input.mousePosition;

            //Tile에서 TileInfo 스크립트에서 TA_Object false true를 체크할 것.
            if (Physics.Raycast(transform.position, dir, out MouseHit, mos.z))
            {
                if (MouseHit.transform.GetComponent<TileInfo>().TA_Object == true)
                {
                    MouseHit.transform.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                    target.position = MouseHit.transform.GetComponent<Transform>().position; //히트한 물체의 transform을 가져오기위해 히트포지션의 컴포넌트를 불러와 이용.
                }
            }
        }
        ObjectCreate(); // 마우스 클릭시, 타일에 건물 설치 유무
    }
    #endregion

}


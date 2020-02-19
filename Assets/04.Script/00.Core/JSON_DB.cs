using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;


//클래스형식의 구조체
#region 몬스터 정보 DB
/// <summary>
/// 고유번호
/// 이름
/// 설명
/// 이동타입
/// 레벨
/// 공격력
/// 공격속도
/// 공격타입
/// 치명타확률
/// 방어력
/// 방어타입
/// 골드
/// 소울
/// </summary>
public class MonsterStats
{
    public int iInherentNumber;
    public string sName;
    public string sDescription;
    public float fMovingType;
    public int iLv;
    public float fAttack;
    public float fAttackSpeed;
    public int fAttackType;
    public float fCritical;
    public float fDefence;
    public int iDefenceType;
    public int iGold;
    public int iSoul;

    public MonsterStats
        (
            int _iInherentNumber,
            string _sName,
            string _sDescription,
            float _fMovingType,
            int _iLv,
            float _fAttack,
            float _fAttackSpeed,
            int _fAttackType,
            float _fCritical,
            float _fDefence,
            int _iDefenceType,
            int _iGold,
            int _iSoul
        )
    {
        iInherentNumber = _iInherentNumber;
        sName = _sName;
        sDescription = _sDescription;
        fMovingType = _fMovingType;
        iLv = _iLv;
        fAttack = _fAttack;
        fAttackSpeed = _fAttackSpeed;
        fAttackType = _fAttackType;
        fCritical = _fCritical;
        fDefence = _fDefence;
        iDefenceType = _iDefenceType;
        iGold = _iGold;
        iSoul = _iSoul;
    }

}
#endregion

#region
#endregion

public class JSON_DB_ENUM : Singleton<JSON_DB_ENUM>
{
    enum DB_LIST
    {
        MONSTERSTATS,END
    }

}


public class JSON_DB : Singleton<JSON_DB>
{
    // 몬스터 스텟 리스트
    List<MonsterStats> MonsterStatsList = new List<MonsterStats>();
    //
    



    // 여기서 저장해야 할 저장 목록중요.
    public void Save() 
    {
        for(int k = 0; k<)
        JsonData Json = JsonMapper.ToJson();
        File.WriteAllText(Application.dataPath + "/Resoureces/" +, Json.ToString());

    }

    public void Load()
    {
        string Jsonstring = File.ReadAllText(Application.dataPath + "/Resources/ItemData.json");

        JsonData itemData = JsonMapper.ToObject(Jsonstring);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    /// <summary>
    /// TA_Object -> There is an Object .
    /// 타일위에 오브젝트가 있는지 판단하는 구조. 
    /// false 는 타일위에 오브젝트가 없다. true 는 타일위에 오브젝트가 있다.
    /// 여기서 오브젝트는 지형물이거나 생성 물체로, 유닛과 같은것은 포함하지 않는다.
    /// </summary>
    public bool TA_Object = false; 


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsBulidFactory
{
    // 건물 생성의 중심이 되는 Factory
    public abstract void CreateBulid();

    /*
    사용법.
    
    AbsBulidFactory (이름) = new BulidFactory();
    
      
     */

}

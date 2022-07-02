using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerD : MonoBehaviour
{
    //RukaMove2(Script)を取得
    public RukaMove2 rukaMove2;
    //InosisiMove2(Script)を取得
    public InosisiMove2 inosisiMove2;
    //AppleScript2(Script)を取得
    public AppleScript2 appleScript2;
    void Update()
    {
        //RukaMove2(Script)のmoveを実行する
        rukaMove2.move(); 
        //RukaMove2(Script)のinosisimvを実行する
        rukaMove2.inosisimv();
        //InosisiMove2(Script)のinosisifollowを実行する
        inosisiMove2.inosisifollow();
        //InosisiMove2(Script)のrockbrを実行する
        //inosisiMove2.rockbr();
        //RukaMove2(Script)のrockdestを実行する
        rukaMove2.rockdest();
        //RukaMove2(Script)のbigrockdestを実行する
        rukaMove2.bigrockdest();
        //AppleScript2(Script)のappledestを実行する
        //appleScript2.appledest();
    }
}

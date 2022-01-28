using System;
using System.Collections.Generic;
using Protocol;
using QFramework;
using UnityEngine;

public class GameModel : Singleton<GameModel>
{
    private GameModel() {}


    public UserDto selfUserDto;
    public MatchRoomDto RoomDto;
    public int LeftPlayer;
    public int RightPlayer;

    public UserDto GetUser(int uid) => RoomDto.UidUserDic[uid];
    public bool IsReady(int uid) => RoomDto.ReadyUidList.Contains(uid);
    

    public override void OnSingletonInit()
    {
        LeftPlayer = -1;
        RightPlayer = -1;
    }

    public void Add(int readyUid, UserDto userDto)
    {
        if (userDto != null)
        {
            int uid = userDto.Id;

            RoomDto.UidList.Add(uid);
            RoomDto.UidUserDic.Add(uid, userDto);
        }

        if (readyUid >= 0)
        {
            RoomDto.ReadyUidList.Add(readyUid);
        }
        
        Refresh();
    }

    public void Remove(int uid, int readyUid)
    {
        if (uid >= 0 && Instance.RoomDto.UidList.Contains(uid) && Instance.RoomDto.UidUserDic.ContainsKey(uid))
        {
            Instance.RoomDto.UidList.Remove(uid);
            Instance.RoomDto.UidUserDic.Remove(uid);
        }

        if (readyUid >= 0 && Instance.RoomDto.ReadyUidList.Contains(uid))
        {
            Instance.RoomDto.ReadyUidList.Remove(uid);
        }
        
        Refresh();
    }

    public void Refresh()
    {
        LeftPlayer = -1;
        RightPlayer = -1;
        
        int selfUid = selfUserDto.Id;
        int flag = 0;
        foreach (var uid in RoomDto.UidList)
        {
            if (selfUid == uid)
                continue;
            flag++;
            if (flag == 1)
                LeftPlayer = uid;
            else if (flag == 2)
                RightPlayer = uid;
        }
    }
}
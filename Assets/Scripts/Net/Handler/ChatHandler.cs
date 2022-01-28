using UnityEngine;
using Protocol;
using QFramework;

public class ChatHandler : HandlerBase
{
    public override void OnReceive(int subCode, object value)
    {
        switch (subCode)
        {
            case (int) SubCode.Chat.SBRO:
                ChatBroadcast(value as ChatDto);
                break;

            default:
                break;
        }
    }

    private void ChatBroadcast(ChatDto dto)
    {
        int uid = dto.SendUid;
        if (GameModel.Instance.LeftPlayer == uid)
        {
            switch (dto.MsgId)
            {
                case 1:
                    UIManager.Instance.SendEvent(UIEventEnum.Fight.LeftChat1);
                    break;
                case 2:
                    UIManager.Instance.SendEvent(UIEventEnum.Fight.LeftChat2);
                    break;
                case 3:
                    UIManager.Instance.SendEvent(UIEventEnum.Fight.LeftChat3);
                    break;
            }
        }
        else if (GameModel.Instance.RightPlayer == uid)
        {
            switch (dto.MsgId)
            {
                case 1:
                    UIManager.Instance.SendEvent(UIEventEnum.Fight.RightChat1);
                    break;
                case 2:
                    UIManager.Instance.SendEvent(UIEventEnum.Fight.RightChat2);
                    break;
                case 3:
                    UIManager.Instance.SendEvent(UIEventEnum.Fight.RightChat3);
                    break;
            }
        }
    }
}
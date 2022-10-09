﻿﻿namespace CommonProtocol
{
    public class ResAccountJoin : CBaseProtocol
    {
        public string userId;
    }

    public class ResLogin : CBaseProtocol
    {
        public string userId;
    }

    public class ResMyPage : CBaseProtocol
    {
        public int winCnt;
        public int lossCnt;
        public int score;
        public string mbti;
        public string userId;
    }

    public class ResTryMatch : CBaseProtocol
    {
        public string ticketId;
    }

    public class ResMatchStatus : CBaseProtocol
    {
        public string IpAddress;
        public string PlayerSessionId;
        public string GameSessionId; 
        public int Port;
        public string teamName;
    }

    public class ResMatchResult : CBaseProtocol
    {
        public int score;
    }
}
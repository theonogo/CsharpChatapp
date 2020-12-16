namespace Communication
{
    //Different possible message sub-types
    public enum MTypes
    {
        CLOSE = 0,
        LOGIN = 1, 
        NEWACC = 2,
        LOGOUT = 3,
        NEWTOP = 4,
        JOINTOP = 5,
        VIEWTOP = 6,
        LEAVETOP = 7,
        CHATMESSAGE = 8,
        CHATWELCOME = 9,
        CHATLEAVE = 10
    }
}
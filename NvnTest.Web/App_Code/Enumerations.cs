using System;

public enum QuestionType
{
    Objective,
    Sql,
    Programming,
    AutoProgramming,
    WebProgramming
}

public enum ProgrammingAnswerType
{
    C,
    CPP,
    CSharp,
    VBNET,
    Java,
    Algo,
    Desc
}

public enum TestStatus
{
    New = 0,
    Taken,
    Submitted,
    Disqualified
}

public enum WebNodeType
{
    Directory,
    CSS,
    JavaScript,
    HTML,
    ASP_DOT_NET
}

public enum PrivilegeType
{
    None,
    View,
    Edit
}

public enum AutoQuestionValueType
{
    String,
    Integer,
    Long,
    Float,
    Double,
    Boolean
}

namespace KIBAEMON2024_Core.Struct;

[Serializable]
public class Authorization
{
    public static Authorization Empty => new();

    public string Token { get; set; } = string.Empty;
}
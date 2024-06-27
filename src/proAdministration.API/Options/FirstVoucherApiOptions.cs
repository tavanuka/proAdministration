namespace proAdministration.API.Options;

public class FirstVoucherApiOptions
{
    public const string SectionName = "FirstVoucher";

    public string Authorization { get; set; } = string.Empty;
    public string Uri { get; set; } = string.Empty;
    public string ApiToken { get; set; } = string.Empty;
}
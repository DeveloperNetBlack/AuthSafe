namespace AuthSafe.Presentation.Areas.Security.Models.Constant
{
    public record struct ConstantListResponseModel
    (
       short ConstantID,
       int ConstantClass,
       string ConstantAbbreviation,
       string ConstantName
    );
}
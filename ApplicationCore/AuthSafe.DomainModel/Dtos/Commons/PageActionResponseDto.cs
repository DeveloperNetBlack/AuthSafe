namespace AuthSafe.DomainModel.Dtos.Commons
{
    public record struct PageActionResponseDto(
     int PageActionID,
     string PageActionName,
     string PageActionDescription
 );
}

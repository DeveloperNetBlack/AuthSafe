namespace AuthSafe.Presentation.Models.RolePermission
{
    public class RolePermissionListResponseModel
    {
        public int IdPage { get; set; }
        public int IdPageParent { get; set; }
        public string PageHierarchy { get; set; } = null!;        
        public string PageName { get; set; } = null!;
        public string PageUrlName { get; set; } = null!;
        public string PageIconName { get; set; } = null!;
        public short PageOrder { get; set; }
    }
}
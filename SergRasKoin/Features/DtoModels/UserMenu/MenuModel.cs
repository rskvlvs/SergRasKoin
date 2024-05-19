namespace SergRasKoin.Features.DtoModels.UserMenu
{
    public class MenuModel
    {
        public Guid UserId { get; init; } 
        
        public string? operation { get; set; }

        public string? UserName { get; set;}

        public string? UserSurname { get; set;}
    }
}

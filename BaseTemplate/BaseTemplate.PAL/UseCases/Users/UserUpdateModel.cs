namespace BaseTemplate.PAL.UseCases.Users;

public class UserUpdateModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
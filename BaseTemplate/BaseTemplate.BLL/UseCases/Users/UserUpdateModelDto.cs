namespace BaseTemplate.BLL.UseCases.Users;

public class UserUpdateModelDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
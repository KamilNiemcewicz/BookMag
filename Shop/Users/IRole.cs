namespace Shop.Users
{
    public interface IRole
    {
        string Name { get; }
    }

    public abstract class RoleBase
    {
        public int Id { get; set; }
        public abstract string Name { get; }
    }

    public class AdminRole : RoleBase, IRole
    {
        public override string Name => "Admin";
    }

    public class RegularUserRole : RoleBase, IRole
    {
        public override string Name => "User";
    }
}
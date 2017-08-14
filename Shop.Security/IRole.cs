using System.Runtime.InteropServices;

namespace Shop.Security
{
    internal interface IRole
    {
        string Name { get; }
    }

    internal abstract class RoleBase
    {
        public int Id { get; set; }
        public abstract string Name { get; }
    }

    internal class AdminRole : RoleBase, IRole
    {
        public override string Name => "Admin";
    }

    internal class RegularUserRole : RoleBase, IRole
    {
        public override string Name => "User";
    }
}
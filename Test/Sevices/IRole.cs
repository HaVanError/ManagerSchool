using Test.Model.DTO;

namespace Test.Sevices
{
    public interface IRole
    {
        RoleDTO Add(RoleDTO role);
        string Remove(int id);
        List<RoleDTO> GetAll();
        string Update(int id, RoleDTO role);
    }
}

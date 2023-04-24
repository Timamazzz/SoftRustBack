namespace SoftRustBack.DTO.Repositories
{
    public interface IRepository<T_DTO, T_DAL> where T_DTO: class where T_DAL : class
    {
        int Create(T_DTO dto);
        List<T_DAL> GetAll();
        T_DAL? GetById(int? id);
        string Update(T_DTO dto);
        string Delete(int id);
    }
}
